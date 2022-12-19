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
    public class Author_VM : Helper
    {
        private int _searchstart;
        private int  _searchend;
        private RelayCommand _authoryears;
       
        public ObservableCollection<Person> Persons { get; } = new();

        public RelayCommand FindAuthoryears => _authoryears ??
            (_authoryears = new RelayCommand((x) =>
            {
               Persons.Clear();
                GutendexMethods cm = new GutendexMethods();
                JObject json = cm.SearchYearAuthor(Searchstart, Searchend);
                var name = " ";
                var date_start = " ";
                var date_end = " ";
                var nameJs =
                from c in json["results"]
                where c["authors"][0]["birth_year"] != null 
                select new
                {
                    name = (string)c["authors"][0]["name"],
                    date_start = (string)c["authors"][0]["birth_year"],
                    date_end = (string)c["authors"][0]["death_year"]

                };
                foreach (var c in nameJs)
                {
                   
                        Persons.Add(new Person()
                        {
                            Name = c.name,
                            BirthYear = c.date_start,
                            DeathYear = c.date_end

                        });                    
                }
                OnPropertyChanged();
            }));

        public int Searchstart
        {
            get => _searchstart;
            set
            {
                _searchstart = value;
                OnPropertyChanged();
            }
        }
        public int Searchend
        {
            get => _searchend;
            set
            {
                _searchend = value;
                OnPropertyChanged();
            }
        }
        
        
    }
}
