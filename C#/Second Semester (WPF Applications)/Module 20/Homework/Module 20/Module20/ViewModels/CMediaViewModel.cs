using Microsoft.Win32;
using Module20.Commons;
using Module20.Models;
using Module20.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

/* ViewModel
 ViewModel или модель представления связывает модель и представление через
 механизм привязки данных. Если в модели изменяются значения свойств, при реализации
 моделью интерфейса INotifyPropertyChanged автоматически идет изменение отображаемых 
 данных в представлении, хотя напрямую модель и представление не связаны.

 ViewModel также содержит логику по получению данных из модели, которые потом передаются
 в представление. И также ViewModel определяет логику по обновлению данных в модели.

 Поскольку элементы представления, т.к. визуальные компоненты типа кнопок, не используют
 события, то представление (View) взаимодействует с ViewModel посредством команд.

 Например, пользователь хочет сохранить введенные в текстовом поле данные.
 Он нажимает на кнопку и тем самым отправляет команду во ViewModel.
 А ViewModel уже получает переданные данные и в соответствии с ними обновляет модель.

 Итогом применения паттерна MVVM является функциональное разделение приложения на 
 три компонента, которые проще разрабатывать и тестировать, также в дальнейшем
 модицицировать и поддерживать.     
*/

namespace Module20.ViewModels
{
    public class CMediaViewModel : NotifyUIBase
    {
        private bool m_IsPlaying = false;
        private bool m_IsSoundSwitchedOn = true;
        private bool m_IsRepeatTrackSwitchedOn = false;
        private double m_CurrentVolumeOfMediaFile = 100;  //for example (hardcoded)

        private OpenFileDialog m_openFileDialog = new OpenFileDialog();


        private long m_OverallQuantityOfPlayingMediaFiles;
        private long m_CurrentNumberOfPlayingMediaFile;

        #region RelayCommand Properties
        public RelayCommand<object> PlayPauseCommand { get; set; } 
        public RelayCommand<object> StopCommand { get; set; }


        public RelayCommand<object> CurrentPathProperty { get; }
        public RelayCommand<object> OpenFileCommand { get; }
        public RelayCommand<object> ExitApplicationCommand { get; set; }

        
        
        public RelayCommand<object> SkipPreviousFileCommand { get; set; }
        public RelayCommand<object> SkipNextFileCommand { get; set; }

        private RelayCommand<object> m_RollForwardMediaUpToCommand { get; set; }
        private RelayCommand<object> m_RollBackwardMediaUpToCommand { get; set; }

        public RelayCommand<object> SwitchSoundCommand { get; }
        #endregion

        private CMediaFile m_MediaFileModel = null;

   
        public event EventHandler PlayEventRequested;
        public void Play()
        {
            if (!ReferenceEquals(PlayEventRequested, null))
                this.PlayEventRequested(this, EventArgs.Empty);
        }

        public event EventHandler PauseEventRequested;
        public void Pause()
        {
            if (!ReferenceEquals(PauseEventRequested, null))
                this.PauseEventRequested(this, EventArgs.Empty);
        }

        public event EventHandler StopEventRequested;
        public void Stop()
        {
            if (!ReferenceEquals(StopEventRequested, null))
                this.StopEventRequested(this, EventArgs.Empty);
        }

        public event EventHandler OverallTimeOfMediaFileIsChangedEventRequested;
        public void OverallTimeOfMediaFileIsChanged()
        {
            if (!ReferenceEquals(OverallTimeOfMediaFileIsChangedEventRequested, null))
                this.OverallTimeOfMediaFileIsChangedEventRequested(this, EventArgs.Empty);
        }

        public event EventHandler CurrentTimeOfMediaFileIsChangedEventRequested;
        public void CurrentTimeOfMediaFileIsChanged()
        {
            if (!ReferenceEquals(CurrentTimeOfMediaFileIsChangedEventRequested, null))
                this.CurrentTimeOfMediaFileIsChangedEventRequested(this, EventArgs.Empty);
        }

        public event EventHandler SwitchSoundOnIsChangedEventRequested;
        public void SwitchSoundOnIsChanged()
        {
            if (!ReferenceEquals(SwitchSoundOnIsChangedEventRequested, null))
                this.SwitchSoundOnIsChangedEventRequested(this, EventArgs.Empty);
        }


        public string FileSourceProperty
        {
            get
            {
                if (ReferenceEquals(m_MediaFileModel, null))
                    return null;
                return m_MediaFileModel.File_FullPath;
            }
            set
            {
                if (ReferenceEquals(m_MediaFileModel, null)) return;
                else
                {
                    m_MediaFileModel.File_FullPath = value;
                    RaisePropertyChanged();
                }
            }
        }

        #region CMediaViewModel constructor
        public CMediaViewModel(CMediaFile _mediaFile)
        {
            m_OverallQuantityOfPlayingMediaFiles = 15; //for example (hardcoded)
            m_CurrentNumberOfPlayingMediaFile = 2; //for example (hardcoded)

            m_IsPlaying = false;

            this.m_MediaFileModel = _mediaFile;

            #region Initialization of RelayCommand Properties

            //Команда проигрывания, либо выставления на паузу медиафайла
            PlayPauseCommand = new RelayCommand<object>((x) =>
            {

                //1) Изменяем отображение кнопки при ее нажатии
                var buttonType = x as Image;
                if (null != buttonType)
                {
                    if (buttonType.Source.ToString().Contains("baseline_play_circle_filled_white_black_18dp"))
                    {
                        //Файл не проигрывается. Пользователю предлагается нажать на кнопку Play, и при клике по ней происходит проигрывание медиа файла
                        Play();
                    }
                    else if (buttonType.Source.ToString().Contains("baseline_pause_circle_filled_black_18dp"))
                    {
                        //Файл проигрывается. Пользователю предлагается нажать на кнопку Pause, и при клике по ней происходит остановка медиа файла
                        Pause();
                    }
                    OverallTimeOfMediaFileIsChanged();
                }


            }, _ => { return m_MediaFileModel.IfExists(); });

            //Команда останова медиафайла
            StopCommand = new RelayCommand<object>(_ => 
            {
                Stop();

                m_MediaFileModel.Clear();

                //И когда кнопка Stop будет нажата, я хочу чтобы обнулились следующие параметры:
                //- Текущее время - CurrentTimeOfMediaFileProperty
                //- Общее время - OverallTimeOfMediaFileProperty
                //- Имя файла - PlayingFileNameWithItsExtentionProperty

                RaisePropertyChanged(nameof(CurrentTimeOfMediaFileProperty));
                RaisePropertyChanged(nameof(OverallTimeOfMediaFileProperty));
                RaisePropertyChanged(nameof(PlayingFileNameWithItsExtentionProperty));
                RaisePropertyChanged(nameof(TypeOfPlayingMediaFileProperty));

            }, _ => { return m_MediaFileModel.IfExists(); });



            SkipPreviousFileCommand = new RelayCommand<object>(_ => { }, _ => { return m_MediaFileModel.IfExists(); });
            SkipNextFileCommand = new RelayCommand<object>(_ => { }, _ => { return m_MediaFileModel.IfExists(); });

            OpenFileCommand = new RelayCommand<object>(
                _ =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        if (!ReferenceEquals(m_MediaFileModel, null))
                        {
                            m_MediaFileModel.File_FullPath = openFileDialog.FileName;
                            m_MediaFileModel.FileName = openFileDialog.SafeFileName;
                            FileSourceProperty = openFileDialog.FileName;
                            RaisePropertyChanged(nameof(PlayingFileNameWithItsExtentionProperty));
                        }
                    }
                }
                , _ => { return !m_MediaFileModel.IfExists(); });

            
            SwitchSoundCommand = new RelayCommand<object>((x) =>
            {
                SwitchSoundOnIsChanged();
            });

            //Команда закрытия приложения
            ExitApplicationCommand = new RelayCommand<object>(_ => { Application.Current.Shutdown(); });
            #endregion
        }
        #endregion


        public bool IsRepeatSoundTrackSwitchedOn
        {
            get { return m_IsRepeatTrackSwitchedOn; }
            set
            {

                m_IsRepeatTrackSwitchedOn = value;
                RaisePropertyChanged();
            }
        }

        public bool IsSoundSwitchedOn
        {
            get { return m_IsSoundSwitchedOn; }
            set { m_IsSoundSwitchedOn = value; RaisePropertyChanged(); }
        }


        public bool IsMediaFilePlayingProperty
        {
            get { return m_IsPlaying; }
            set
            {
                m_IsPlaying = value;
                RaisePropertyChanged();
            }
        }

        public double CurrentVolumeOfMediaFile
        {
            get { return m_CurrentVolumeOfMediaFile; }
            set
            {
                m_CurrentVolumeOfMediaFile = value;
                RaisePropertyChanged();
            }
        }

        


        #region CurrentTimeOfMediaFile property
        public TimeSpan CurrentTimeOfMediaFileProperty
        {
            get
            {
                return m_MediaFileModel.CurrentPosition;
            }
            set
            {
                m_MediaFileModel.CurrentPosition = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region OverallTimeOfMediaFile property
        public TimeSpan OverallTimeOfMediaFileProperty
        {
            get
            {
                return m_MediaFileModel.Length;
            }
            set
            {
                m_MediaFileModel.Length = value;
                RaisePropertyChanged();
            }

        }
        #endregion

        #region NumberOfPlayingMediaFile Property
        public string NumberOfPlayingMediaFileProperty
        {
            get
            {
                return string.Format(@"[{0}/{1}]", m_CurrentNumberOfPlayingMediaFile, m_OverallQuantityOfPlayingMediaFiles);
            }
        }
        #endregion


        #region FileExtentionOfPlayingMediaFile Property
        public string PlayingFileNameWithItsExtentionProperty
        {
            get { return m_MediaFileModel.FileName; }
            set
            {
                m_MediaFileModel.FileName = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region BitRateOfPlayingMediaFile Property
        public string BitRateOfPlayingMediaFileProperty
        {
            get { return m_MediaFileModel.Audio_BitRate; }
            set
            {
                m_MediaFileModel.Audio_BitRate = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region FrequencyOfPlayingMediaFile Property
        public string FrequencyOfPlayingMediaFileProperty
        {
            get { return m_MediaFileModel.Audio_Frequency;  }
            set
            {
                m_MediaFileModel.Audio_Frequency = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region TypeOfPlayingMediaFileProperty Property
        public string TypeOfPlayingMediaFileProperty
        {
            get { return m_MediaFileModel.File_ItemType; }
            set
            {
                m_MediaFileModel.File_ItemType = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }


}
