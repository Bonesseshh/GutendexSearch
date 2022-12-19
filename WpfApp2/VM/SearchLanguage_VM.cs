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
    public class SearchLanguage_VM : Helper
    {
       
        
        private string _search;
        private RelayCommand _languagesearch;
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
        public RelayCommand LanguageSearch => _languagesearch ??
            (_languagesearch = new RelayCommand((x) =>
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
                    JObject json = cm.Language(Search);
                    var id = 0;
                    var title = " ";
                    var languagess = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Languagess = (JArray)json["results"][0]["languages"];
                    IList<string> languagesText = Languagess.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var language in languagesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Languages = language

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
                    JObject json = cm.Sort(sort);
                    var id = 0;
                    var title = " ";
                    var languagess = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Languagess = (JArray)json["results"][0]["languages"];
                    IList<string> languagesText = Languagess.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var language in languagesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Languages = language

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
                    JObject json = cm.Sort(sort);
                    var id = 0;
                    var title = " ";
                    var languagess = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Languagess = (JArray)json["results"][0]["languages"];
                    IList<string> languagesText = Languagess.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var language in languagesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Languages = language

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
                    JObject json = cm.Sort(sort);
                    var id = 0;
                    var title = " ";
                    var languagess = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    JArray Languagess = (JArray)json["results"][0]["languages"];
                    IList<string> languagesText = Languagess.Select(c => (string)c).ToList();
                    foreach (var c in nameJs)
                    {

                        foreach (var language in languagesText)
                        {
                            Books.Add(new Book()
                            {
                                Id = c.id,
                                Title = c.title,
                                Languages = language

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
