using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.VM;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для SearchCopyright.xaml
    /// </summary>
    public partial class SearchCopyright : Page
    {
        public SearchCopyright()
        {
            InitializeComponent();
            DataContext = new SearchCopyright_VM();
        }
    }
}
