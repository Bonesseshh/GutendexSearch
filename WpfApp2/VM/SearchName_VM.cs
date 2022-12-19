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
    public class SearchName_VM : Helper
    {
        private string _search;
        private RelayCommand _namesearch;
        private RelayCommand _sortpopular;
        private RelayCommand _sortascending;
        private RelayCommand _sortdescending;
        public ObservableCollection<PersonBook> PersonBooks { get; } = new();
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand Namesearch => _namesearch ??
        (_namesearch = new RelayCommand((x) =>
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
                
                
                    GutendexMethods cm = new GutendexMethods();
                    PersonBooks.Clear();
                    JObject json = cm.Name(Search);

                if (json["previous"] != null)
                {
                    var id = 0;
                    var title = " ";
                    var name = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        name = (string)c["authors"][0]["name"],
                        id = (int)c["id"],
                        title = (string)c["title"]

                    };
                    foreach (var c in nameJs)
                    {
                        PersonBooks.Add(new PersonBook()
                        {
                            Id = c.id,
                            Title = c.title,
                            Name = c.name

                        });
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели некорректные данные!");
                }               
            }
            else if (sort == "popular")
            {
                try
                {
                    PersonBooks.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Sort(sort);
                    var id = 0;
                    var title = " ";
                    var name = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        name = (string)c["authors"][0]["name"]

                    };
                    foreach (var c in nameJs)
                    {
                        PersonBooks.Add(new PersonBook()
                        {
                            Id = c.id,
                            Title = c.title,
                            Name = c.name

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
                    PersonBooks.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Sort(sort);
                    var id = 0;
                    var title = " ";
                    var name = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        name = (string)c["authors"][0]["name"]
                    };
                    foreach (var c in nameJs)
                    {
                        PersonBooks.Add(new PersonBook()
                        {
                            Id = c.id,
                            Title = c.title,
                            Name = c.name

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
                    PersonBooks.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Sort(sort);
                    var id = 0;
                    var title = " ";
                    var name = " ";
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        name = (string)c["authors"][0]["name"]
                    };
                    foreach (var c in nameJs)
                    {
                        PersonBooks.Add(new PersonBook()
                        {
                            Id = c.id,
                            Title = c.title,
                            Name = c.name
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
