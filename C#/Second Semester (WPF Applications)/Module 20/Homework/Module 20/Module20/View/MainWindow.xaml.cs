using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Module20.Resources;
using Module20.ViewModels;
using System.IO;
using System.Windows.Threading;

namespace Module20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Задание 20. Media Player (XAML, ControlTemplate, DataTemplate, Style)
    /// Реализуйте упрощенный аналог Windows Media Player. Программа должна предоставлять возможность
    /// воспроизведения музыкальных файлов (для желающих и видео). Кнопки в проигрывателе должны быть
    /// нестандартными (например, круглыми) и визуально реагировать на наведение мышки, нажатие,
    /// недоступность действия (IsEnabled). Проигрыватель должен отображать список воспроизводимых
    /// композиций (play list), который должен синхронизоваться с воспроизводимой композицией.
    /// 
    /// Примечание.
    /// Для воспроизведения медиа контента используйте MediaElement (если не хотите отображать медиа
    /// элемент на экране (т.е. без видео), то можно использовать MediaPlayer).
    /// Для создания нестандартных кнопок используйте ControlTemplate.
    /// Для реализации реакции на наведение мышки, нажатие, недоступность действия используйте триггеры
    /// в ControlTemplate.
    /// Для автоматического применения шаблона используйте автоматически применяемый стиль для кнопок.
    /// При отображении списка воспроизводимых композиций используйте DataTemplate.
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.01);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
            timerVideoTime.Start();
        }

        //The actual timer handler
        private void timer_Tick(object sender, EventArgs e)
        {
           if ((!ReferenceEquals(DataContext, null) && DataContext is CMediaViewModel) &&
               ((!ReferenceEquals(myMediaElement, null)) && (myMediaElement.HasAudio || myMediaElement.HasVideo) && myMediaElement.NaturalDuration.HasTimeSpan))
            {
                CMediaViewModel ViewModel = (CMediaViewModel)DataContext;
                if (myMediaElement.NaturalDuration.TimeSpan.TotalSeconds >= 0 && ViewModel.IsMediaFilePlayingProperty)
                {
                    ViewModel.CurrentTimeOfMediaFileIsChanged();
                }
            }
        }

        //Когда окно загружается, то вызывается метод Window_Loaded.
        //1) Т.к. DataContext определяется не в xaml файле, а в методе OnStartup в файле App.xaml.cs, 
        //то DataContext представляет собой отражение CMediaViewModel и теперь он взаимосвязан с xaml файлом с 
        //возможностью производить привязку свойств и вызов команд
        //2) Более того, т.к. с т.з. модели MVVM представление (View) не должно взаимодействовать напрямую с ViewModel,
        //то я решил эту проблему следующим образом: создал событие во ViewModel, а подписался на это событие во View.
        //Итого: представление напрямую не взаимодействует с ViewModel
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(DataContext, null) && DataContext is CMediaViewModel && !ReferenceEquals(myMediaElement, null))
            {
                CMediaViewModel ViewModel = (CMediaViewModel)DataContext;

                //Во View нажали на кнопку Play, это спровоцировало вызов свойство PlayPauseCommand во ViewModel, 
                //где в свою очередь производится вызов лямбда-функции, где в конце концов определяется при нажатии по кнопке
                //вызовется ли "Play" или "Pause"
                {
                    //Подписываемся на вызов события "Play"
                    ViewModel.PlayEventRequested += (s, ev) =>
                    {
                        myMediaElement.Play(); //Вызов метода проигрывания медиафайла
                        myMediaElement.Visibility = Visibility.Visible; //При проигрывании медиафайла, делаем картинку видимой

                        ViewModel.IsMediaFilePlayingProperty = true; //Когда выставляется данное свойство в true, в XAML происходит смена картинки на Pause посредством DataTrigger
                    };

                    //Подписываемся на вызов события  "Pause"
                    ViewModel.PauseEventRequested += (s, ev) =>
                    {
                        this.myMediaElement.Pause(); //Вызов метода выставления на паузу медиафайла
                        myMediaElement.Visibility = Visibility.Visible; //При паузе делаем картинку также видимой.

                        ViewModel.IsMediaFilePlayingProperty = false; //Когда выставляется данное свойство в false, в XAML происходит смена картинки на Play посредством DataTrigger
                    };

                    //Подписываемся на вызов события  "Stop"
                    ViewModel.StopEventRequested += (s, ev) =>
                    {
                        this.myMediaElement.Stop(); //Вызов метода остановки медиафайла
                        myMediaElement.Visibility = Visibility.Hidden; //При остановке медиафайла картинку мы скрываем

                        ViewModel.IsMediaFilePlayingProperty = false; //Когда выставляется данное свойство в false, в XAML происходит смена картинки на Play посредством DataTrigger

                        timelineSlider.Value = 0;
                    };

                    //Подписываемся на вызов события "Запрос на изменение отображения в View общей длительности медиафайла"
                    ViewModel.OverallTimeOfMediaFileIsChangedEventRequested += (s, ev) =>
                    {
                        if ((myMediaElement.HasAudio || myMediaElement.HasVideo) && myMediaElement.NaturalDuration.HasTimeSpan)
                        {
                            ViewModel.OverallTimeOfMediaFileProperty = myMediaElement.NaturalDuration.TimeSpan;
                        }
                    };

                    //Подписываемся на вызов события "Запрос на изменение отображения во View текущего проигрываемого времени медиафайла"
                    ViewModel.CurrentTimeOfMediaFileIsChangedEventRequested += (s, ev) =>
                    {
                        if ((myMediaElement.HasAudio || myMediaElement.HasVideo) && myMediaElement.NaturalDuration.HasTimeSpan)
                        {
                            timelineSlider.Value = (double)myMediaElement.Position.Ticks / (double)ViewModel.OverallTimeOfMediaFileProperty.Ticks;
                            ViewModel.CurrentTimeOfMediaFileProperty = myMediaElement.Position;
                        }
                    };

                    //Подписываемся на вызов события  "Запрос на включение/отключение звука"
                    ViewModel.SwitchSoundOnIsChangedEventRequested += (s, ev) =>
                    {
                        ViewModel.IsSoundSwitchedOn = ViewModel.IsSoundSwitchedOn ? false : true;

                        //Определяем включен звук или нет при помощи свойство во ViewModel, которое дергается через View
                        myMediaElement.IsMuted = !ViewModel.IsSoundSwitchedOn;
                    };

                    //Подписываемся на вызов события  "Запрос на изменение звука"
                    SoundController.ValueChanged += (s, ev) =>
                    {
                        ViewModel.CurrentVolumeOfMediaFile = myMediaElement.Volume = SoundController.Value;

                        ViewModel.IsSoundSwitchedOn = myMediaElement.Volume > 0 ? true : false;
                    };

                    //Подписываемся на вызов события, когда начнется исполнение медиафайла
                    myMediaElement.MediaOpened += (s, ev) =>
                    {
                        if(ViewModel.IsMediaFilePlayingProperty)
                        {
                            ViewModel.OverallTimeOfMediaFileIsChanged();
                        }
                    };

                    //Подписываемся на вызов события, когда исполнение медиафайла завершится
                    myMediaElement.MediaEnded += (s, ev) =>
                    {
                        myMediaElement.Stop();
                        ViewModel.IsMediaFilePlayingProperty = false;
                        myMediaElement.Visibility = Visibility.Visible;
                        timelineSlider.Value = 0;

                        //Если включена кнопка повтора воспроизведения медиафайла, то зацикливаем этот процесс
                        if (ViewModel.IsRepeatSoundTrackSwitchedOn)
                        {
                            myMediaElement.Play();
                            ViewModel.IsMediaFilePlayingProperty = true;
                        }
                    };


                    timelineSlider.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler((s, ev) =>
                    {
                        if (ViewModel.IsMediaFilePlayingProperty)
                            ViewModel.Pause();

                        ViewModel.CurrentTimeOfMediaFileProperty = TimeSpan.FromTicks(myMediaElement.Position.Ticks);

                        timelineSlider.Value = (double)ViewModel.CurrentTimeOfMediaFileProperty.Ticks / (double)ViewModel.OverallTimeOfMediaFileProperty.Ticks;

                    }), true);

                    timelineSlider.AddHandler(MouseLeftButtonUpEvent, new MouseButtonEventHandler((s, ev) =>
                    {
                        if (!(ViewModel.IsMediaFilePlayingProperty))
                        {
                            double dblPositionInMilliseconds = (double)ViewModel.OverallTimeOfMediaFileProperty.TotalMilliseconds * timelineSlider.Value;

                            myMediaElement.Position = TimeSpan.FromMilliseconds(dblPositionInMilliseconds);

                            ViewModel.Play();
                        }
                    }), true);
                }

            } //end if (!ReferenceEquals(DataContext, null) && DataContext is CMediaViewModel && !ReferenceEquals(myMediaElement, null))
        }    
    }
}