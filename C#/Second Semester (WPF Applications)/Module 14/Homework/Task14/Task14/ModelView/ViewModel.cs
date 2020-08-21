using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp5.ModelView
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model m_model;
        public bool flgIsDocumentModified = false;
        public bool flgCanDocumentBeSaved = true;

        public RelayCommand<object> NewCommand { get; private set; }
        public RelayCommand<object> OpenCommand { get; private set; }
        public RelayCommand<object> SaveCommand { get; private set; }
        public RelayCommand<object> SaveAsCommand { get; private set; }

        public ViewModel(Model model)
        {
            this.m_model = model;

            NewCommand = new RelayCommand<object>(New);
            OpenCommand = new RelayCommand<object>(Open);
            SaveCommand = new RelayCommand<object>(Save, _ => flgCanDocumentBeSaved);
            SaveAsCommand = new RelayCommand<object>(SaveAs);
        }

        public Model Model
        {
            get { return m_model; }
        }

        public string Title
        {
            get
            {
                if(Path is null)
                {
                    return "Безымянный текстовый файл";
                }
                else
                {
                    return System.IO.Path.GetFileName(m_model.m_path);
                }
            }
        }
        public string Path
        {
            get { return m_model.m_path; }
            set { m_model.m_path = value; RaisePropertyChanged(); }
        }

        public string Text
        {
            get { return m_model.m_text; }
            set
            {
                m_model.m_text = value;
                flgIsDocumentModified = true;
                flgCanDocumentBeSaved = true;
                RaisePropertyChanged();
            }
        }

        public bool CanDocumentBeClosed()
        {
            if(flgIsDocumentModified)
            {
                String @string = String.Format("Document {0} has been changed. Would you like to save this document?", Path is null? "" : Path);
                MessageBoxResult result = MessageBox.Show(@string, "Save Changes?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    if(Path is null)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Text Documents|*.txt|All Documents|*.*";
                        if (saveFileDialog.ShowDialog() == false)
                        {
                            return false;
                        }
                        m_model.SaveAs(saveFileDialog.FileName);
                    }
                    else
                    {
                        m_model.Save();
                    }
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return false;
                }
            }
            
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void New(object obj)
        {
            if(CanDocumentBeClosed())
            {
                m_model.Clear();
                flgIsDocumentModified = false;
                flgCanDocumentBeSaved = true;
                RaisePropertyChanged();
            }
        }

        private void Open(object obj)
        {
            if(CanDocumentBeClosed())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Documents|*.txt|All Files|*.*";

                if(openFileDialog.ShowDialog() == true)
                {
                    m_model.Open(openFileDialog.FileName, m_model.m_encoding);
                    flgIsDocumentModified = false;
                    flgCanDocumentBeSaved = false;
                    RaisePropertyChanged();
                }
            }
        }

        private void Save(object obj)
        {
            if(Path is null)
            {
                SaveAs(new Model());
            }
            else
            {
                m_model.Save();
                flgCanDocumentBeSaved = false;
                flgIsDocumentModified = false;
                RaisePropertyChanged();
            }
        }

        private void SaveAs(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                m_model.SaveAs(dialog.FileName);

                flgCanDocumentBeSaved = false;
                flgIsDocumentModified = false;
                RaisePropertyChanged();
            }
        }
    }
}
