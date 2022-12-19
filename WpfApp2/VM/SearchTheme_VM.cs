using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Model;

namespace WpfApp2.VM
{
    public class SearchTheme_VM : Helper
    {
       
            private string _search;
        private RelayCommand _themesearch;
        private RelayCommand _sortpopular;
        private RelayCommand _sortascending;
        private RelayCommand _sortdescending;
        public ObservableCollection<Book> Books { get; } = new();
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand ThemeSearch => _themesearch ??
            (_themesearch = new RelayCommand((x) =>
            {
                Sorted("none");
            }));
        public RelayCommand Popular => _sortpopular ??
        (_sortpopular = new RelayCommand((x) =>
        {
            Sorted("popular");
        }));
        public RelayCommand Ascending => _sortascending ??
        (_sortascending = new RelayCommand((x) =>
        {
            Sorted("ascending");
        }));
        public RelayCommand Descending => _sortdescending ??
        (_sortdescending = new RelayCommand((x) =>
        {
            Sorted("descending");
        }));
        void Sorted(string sort)
        {
            if (sort == "none")
            {
                Books.Clear();
                GutendexMethods cm = new GutendexMethods();
                try
                {                   
                    JObject json = cm.Theme(Search);
                    var id = 0;
                    var title = " ";
                    var bookshelves = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Bookshelves = (JArray)json["results"][0]["bookshelves"];
                    IList<string> bookshelvesText = Bookshelves.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var booksh in bookshelvesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Bookshelves = booksh

                            });
                        }
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                    MessageBox.Show("Вы ввели некорректные данные!");
                }

            }
            else if (sort == "popular")
            {
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Theme(Search);
                    var id = 0;
                    var title = " ";
                    var bookshelves = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Bookshelves = (JArray)json["results"][0]["bookshelves"];
                    IList<string> bookshelvesText = Bookshelves.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var booksh in bookshelvesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Bookshelves = booksh

                            });
                        }
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                    MessageBox.Show("Вы ввели некорректные данные!");
                }
            }
            else if (sort == "ascending")
            {
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Theme(Search);
                    var id = 0;
                    var title = " ";
                    var bookshelves = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Bookshelves = (JArray)json["results"][0]["bookshelves"];
                    IList<string> bookshelvesText = Bookshelves.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var booksh in bookshelvesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Bookshelves = booksh

                            });
                        }
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                    MessageBox.Show("Вы ввели некорректные данные!");
                }
            }
            else if (sort == "descending")
            {
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Theme(Search);
                    var id = 0;
                    var title = " ";
                    var bookshelves = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Bookshelves = (JArray)json["results"][0]["bookshelves"];
                    IList<string> bookshelvesText = Bookshelves.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var booksh in bookshelvesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Bookshelves = booksh

                            });
                        }
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                    MessageBox.Show("Вы ввели некорректные данные!");
                }
            }
        }         
    }
}
