using WpfApp2.Model;
using WpfApp2.Pages;
using WpfApp2.VM;

namespace WpfApp2
{
    public class MainWindow_VM : Helper
    {       
        private RelayCommand _allbooks;
        private RelayCommand _author;
        private RelayCommand _artikul;
        private RelayCommand _language;
        private RelayCommand _mimetype;
        private RelayCommand _name;
        private RelayCommand _theme;
        private RelayCommand _searchcopyright;
        //private RelayCommand _newtask;
        
        public RelayCommand SearchBooks => _allbooks ??
            (_allbooks = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new SearchBooks());
            }));
        public RelayCommand Author => _author ??
            (_author = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new Author());
            }));
        public RelayCommand ArtikulSearch => _artikul ??
            (_artikul = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new ArtikulSearch());
            }));
        public RelayCommand SearchLanguage => _language??
            (_language = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new SearchLanguage());
            }));
        public RelayCommand SearchMIMEtype => _mimetype ??
            (_mimetype = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new SearchMIMEtype());
            }));
        public RelayCommand SearchName => _name ??
            (_name = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new SearchName());
            }));
        public RelayCommand SearchTheme => _theme ??
            (_theme = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new SearchTheme());
            }));
        public RelayCommand SearchCopyright => _searchcopyright ??
            (_theme = new RelayCommand((x) =>
            {
                Service.frame.Navigate(new SearchCopyright());
            }));
    }      
}

