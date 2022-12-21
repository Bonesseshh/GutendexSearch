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
    public class SearchMIMEtype_VM : Helper
    {
        private string _search;
        private RelayCommand _mimetypesearch;
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
        public RelayCommand Mimetypesearch => _mimetypesearch ??
            (_mimetypesearch = new RelayCommand((x) =>
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
                    JObject json = cm.MIMEtype(Search);                    
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        mime_type = (string)c["media_type"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            MediaType = c.mime_type

                        });
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            else if (sort == "popular")
            {
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Sort(sort);                    
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        mime_type = (string)c["media_type"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            MediaType = c.mime_type

                        });
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                    
                }

            }
            else if (sort == "ascending")
            {
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Sort(sort);                 
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        mime_type = (string)c["media_type"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            MediaType = c.mime_type

                        });
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                   
                }
            }
            else if (sort == "descending")
            {
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.Sort(sort);                 
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        id = (int)c["id"],
                        title = (string)c["title"],
                        mime_type = (string)c["media_type"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Id = c.id,
                            Title = c.title,
                            MediaType = c.mime_type

                        });
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }



    
        


    
}
