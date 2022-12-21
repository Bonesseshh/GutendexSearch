using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.VM
{
    public  class AllBooks_VM : Helper
    {
        private RelayCommand _allbooks;
        private RelayCommand _sortpopular;
        private RelayCommand _sortascending;
        private RelayCommand _sortdescending;      
            public ObservableCollection<Book> Books { get; } = new();
            public RelayCommand AllBooksSearch => _allbooks ??
            (_allbooks = new RelayCommand((x) =>
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
        public void Sorted(string sort)
        {                  
            if (sort == "none")
            {
                try
                {
                    Books.Clear();
                    GutendexMethods cm = new GutendexMethods();
                    JObject json = cm.AllBooks();
                    var nameJs =
                    from c in json["results"]
                    select new
                    {
                        title = (string)c["title"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Title = c.title

                        });
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                  
                }                    
            }
                                
            else if(sort == "popular")
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
                        title = (string)c["title"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Title = c.title

                        });
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                 
                }               
            }
            else if(sort == "ascending")
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
                        title = (string)c["title"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Title = c.title

                        });
                    }
                    OnPropertyChanged();
                }
                catch (Exception)
                {

                }               
            }
            else if(sort == "descending")
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
                        title = (string)c["title"]

                    };
                    foreach (var c in nameJs)
                    {
                        Books.Add(new Book()
                        {
                            Title = c.title

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
