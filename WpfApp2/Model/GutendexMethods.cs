using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class GutendexMethods
    {
        private GutendexSession _gutsession;
        public GutendexMethods()
        {
            GutendexSession gutendexSession = new GutendexSession();
            _gutsession = gutendexSession;
        }

        public JObject? SearchYearAuthor(int start_date, int end_date)
        {
            string url = $"https://gutendex.com/books?author_year_start={start_date}/&author_year_end=/{end_date}";
            return _gutsession.query(url);
        }
        public JObject? AllBooks()
        {
            string url = "https://gutendex.com/books";
            return _gutsession.query(url);
        }
        public JObject? Artikul(int ids)
        {
            string url = $"https://gutendex.com/books?ids={ids}";
            return _gutsession.query(url);
        }
        public JObject? Language(string languages)
        {
            string url = $"https://gutendex.com/books?languages={languages}";
            return _gutsession.query(url);
        }
        public JObject? MIMEtype(string mime_type)
        {
            string url = $"https://gutendex.com/books?mime_type={mime_type}";
            return _gutsession.query(url);
        }
        public JObject? Name(string search)
        {
            string url = $"https://gutendex.com/books?search={search}";
            return _gutsession.query(url);
        }
        public JObject? Theme(string topic)
        {
            string url = $"https://gutendex.com/books?topic={topic}";
            return _gutsession.query(url);
        }
        public JObject? Copyright(string copyright)
        {
            string url = $"https://gutendex.com/books?copyright={copyright}";
            return _gutsession.query(url);
        }
        public JObject? Sort(string sorting)
        {
            string url = $"https://gutendex.com/books?sort={sorting}";
            return _gutsession.query(url);
        }

    }
}
