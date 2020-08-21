using Microsoft.Win32;
using Module17.Common;
using Module17.DAL;
using Module17.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Module17
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Model m_model;
        private ObservableCollection<Book> m_books;
        private Book m_selectedBook;
        private ObservableCollection<Author> m_authors;
        private Author m_selectedAuthor;

        private int m_year_of_production;

        private bool CanBeSaved = true;

        public RelayCommand<object> LoadCommand { get; private set; }
        public RelayCommand<object> SaveCommand { get; private set; }
        public RelayCommand<object> SaveAsCommand { get; private set; }

        public RelayCommand<object> AddBookCommand { get; private set; }
        public RelayCommand<object> DeleteBookCommand { get; private set; }
        public RelayCommand<object> AddAuthorCommand { get; private set; }
        public RelayCommand<object> DeleteAuthorCommand { get; private set; }
        
        public RelayCommand<object> OpenCommand { get; private set; }
        public RelayCommand<object> ExitCommand { get; private set; }

        public ObservableCollection<Book> Books
        {
            get { return m_books; }
            set { m_books = value; RaisePropertyChanged(); }
        }

        public Book SelectedBook
        {
            get { return m_selectedBook; }
            set { SetCurrentBook(value); }
        }
        public ObservableCollection<Author> Authors
        {
            get { return m_authors; }
            set {
                m_authors = value;
                RaisePropertyChanged();

                if (m_selectedBook != null)
                {
                    m_selectedBook.Authors = value.ToArray();
                }
                CanBeSaved = true;
            }
        }

        public Author SelectedAuthor
        {
            get { return m_selectedAuthor; }
            set { m_selectedAuthor = value; RaisePropertyChanged(); }
        }

        public int Year_Of_Production
        {
            get { return m_year_of_production; }
            set { SetCurrentYearOfProduction(value); }
        }

        public MainViewModel(Model _model)
        {
            this.m_model = _model;
            if(!ReferenceEquals(m_model.Books, null))
            {
                Books = new ObservableCollection<Book>(m_model.Books);
            }
            else
            {
                Books = new ObservableCollection<Book>();
            }

            if(Books.Count > 0)
            {
                SelectedBook = Books[0];
            }

            AddBookCommand = new RelayCommand<object>(AddBook);
            DeleteBookCommand = new RelayCommand<object>(DeleteBook, _ => { return SelectedBook != null; });
            AddAuthorCommand = new RelayCommand<object>(AddAuthor, _ => { return SelectedBook != null; });
            DeleteAuthorCommand = new RelayCommand<object>(DeleteAuthor, _ => { return SelectedAuthor != null; });

            LoadCommand = new RelayCommand<object>(Load, _ => { return m_model.Path != ""; });
            SaveCommand = new RelayCommand<object>(Save, _ => { return CanBeSaved; });
            SaveAsCommand = new RelayCommand<object>(SaveAs);
            
           
            
            
            OpenCommand = new RelayCommand<object>(Open);
            ExitCommand = new RelayCommand<object>(_ => { Application.Current.Shutdown(); });
        }

        private void Load(object obj)
        {
            if (ReferenceEquals(m_model.Path, null) || m_model.Path == "") return;
            if (m_model.LoadDefaultPath())
            {
                Books = new ObservableCollection<Book>(m_model.Books);
                if (Books.Count > 0)
                {
                    SelectedBook = Books[0];
                }
                CanBeSaved = false;
            }
            else
            {
                MessageBox.Show("Не удалось загрузить " + m_model.Path, "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Save(object obj)
        {
            if (ReferenceEquals(m_model.Path, null) || m_model.Path == "")
            {
                SaveAs(new object());
            }
            else
            {
                m_model.Books = Books.ToArray();
                m_model.Save();
                CanBeSaved = false;
                RaisePropertyChanged();
            }
        }

        private void SaveAs(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Book Library (*.xml)|*.xml|All Files (*.*)|*.*";
            dialog.FileName = "library.xml";

            if (dialog.ShowDialog() == true)
            {
                m_model.Books = Books.ToArray();
                m_model.SaveAs(dialog.FileName);
                CanBeSaved = false;
                RaisePropertyChanged();
            }
        }

        private void AddBook(object obj)
        {
            Book book = new Book() { Title = "" };
            Books.Add(book);
            SelectedBook = book;
            CanBeSaved = true;
        }
        private void DeleteBook(object obj)
        {
            int i = Books.IndexOf(SelectedBook);
            Books.Remove(SelectedBook);
            if (Books.Count > 0)
            {
                if (i > 1)
                {
                    SelectedBook = Books[i - 1];
                }
                else
                {
                    SelectedBook = Books[0];
                }
            }
            else
            {
                SelectedBook = null;
            }
            CanBeSaved = true;
        }
        private void AddAuthor(object obj)
        {
            if (m_selectedBook is null) return;

            Author author = new Author();
            Authors.Add(author);
            SelectedAuthor = author;
            SelectedBook.Authors = Authors.ToArray();
            CanBeSaved = true;
        }
        private void DeleteAuthor(object obj)
        {
            if (SelectedAuthor is null || Authors is null) return;
            int i = Authors.IndexOf(SelectedAuthor);
            Authors.Remove(SelectedAuthor);
            SelectedBook.Authors = Authors.ToArray();
            if (Authors.Count > 0)
            {
                if (i > 1)
                {
                    SelectedAuthor = Authors[i - 1];
                }
                else
                {
                    SelectedAuthor = Authors[0];
                }
            }
            else
            {
                m_selectedAuthor = null;
            }
            CanBeSaved = true;
        }
        private void Open(object obj)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Book Library (*.xml)|*.xml|All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if(dialog.ShowDialog() == true)
            {
                if(m_model.LoadSpecificPath(dialog.FileName))
                {
                    Books = new ObservableCollection<Book>(m_model.Books);
                    if (Books.Count > 0)
                    {
                        SelectedBook = Books[0];
                    }
                    CanBeSaved = false;
                }
            }
            else
            {
                MessageBox.Show("Не удалось загрузить " + dialog.FileName, "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public void SetCurrentBook(Book _book, [CallerMemberName] string propertyName = "")
        {
            if(this.m_selectedBook != _book)
            {
                this.m_selectedBook = _book;
                Year_Of_Production = (m_selectedBook?.Year_of_production) ?? 0;

                if (ReferenceEquals(m_selectedBook, null) || ReferenceEquals(m_selectedBook.Authors, null))
                {
                    Authors = new ObservableCollection<Author>();
                }
                else
                {
                    Authors = new ObservableCollection<Author>(m_selectedBook.Authors);
                }
                RaisePropertyChanged(propertyName);
            }
        }

        private void SetCurrentYearOfProduction(int _year_of_production, [CallerMemberName] string propertyName = "")
        {
            this.m_year_of_production = _year_of_production;
            if(!ReferenceEquals(this.m_selectedBook, null))
            {
                this.m_selectedBook.Year_of_production = this.m_year_of_production;
            }
            RaisePropertyChanged(propertyName);
            CanBeSaved = true;
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
