using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;
using WpfApp2.VM;

namespace WpfApp2
{
    public class Test
    {

        private GutendexMethods _gutendexMethods;
        private Author_VM _allBooksVM;
        [SetUp]
        public void SetUp()
        {
            _gutendexMethods = new GutendexMethods();
            _allBooksVM = new Author_VM();
        }
        [TestCase(1800, 1900)]
        public void CheckAllBooks(int start_date, int end_date)
        {
            var result = _gutendexMethods.SearchYearAuthor(start_date, end_date);
            Assert.IsNotNull(result);
        }
        [TestCase(1)]
        public void jopen(int s)
        {
            var result = _gutendexMethods.jopa(s);
            Assert.IsTrue(result);
        }
        
    }
}
