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
    public class SearchCopyright_VM : Helper
    {
        private string _search;
        private RelayCommand _copyrightsearch;
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
        public RelayCommand Copyrightsearch => _copyrightsearch ??
            (_copyrightsearch = new RelayCommand((x) =>
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
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Copyright(Search);
                    var id = 0;
                    var title = " ";
                    var copyrights = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        copyright = (bool)c["copyright"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            Copyright = c.copyright

                        });
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
                    var copyrights = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        copyright = (bool)c["copyright"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            Copyright = c.copyright

                        });
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
                    var copyrights = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        copyright = (bool)c["copyright"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            Copyright = c.copyright

                        });
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
                    var copyrights = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        copyright = (bool)c["copyright"]
                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            Copyright = c.copyright

                        });
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
