using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace _6.Model
{
    public class MainPageTheme: INotifyPropertyChanged
    {
        public MainPageTheme(int HeaderFontSize,int ContentFontSize, ElementTheme Theme, string Title)
        {
            this.HeaderFontSize = HeaderFontSize;
            this.ContentFontSize = ContentFontSize;
            this.Theme = Theme;
            this.Title = Title;
        }
        private int _HeaderFontSize { get; set; }
        public int HeaderFontSize
        {
            get
            {
                return _HeaderFontSize;
            }
            set
            {
                if (value == _HeaderFontSize)
                {
                    return;
                }
                _HeaderFontSize = value;
                RaisePropertyChanged("HeaderFontSize");
            }
        }
        private int _ContentFontSize { get; set; }
        public int ContentFontSize
        {
            get
            {
                return _ContentFontSize;
            }
            set
            {
                if (value == _ContentFontSize)
                {
                    return;
                }
                _ContentFontSize = value;
                RaisePropertyChanged("ContentFontSize");
            }
        }
        private ElementTheme _Theme { get; set; }
        public ElementTheme Theme
        {
            get
            {
                return _Theme;
            }
            set
            {
                if (value == _Theme)
                {
                    return;
                }
                _Theme = value;
                RaisePropertyChanged("Theme");
            }
        }
        private string _Title { get; set; }
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if(value=="地球人")
                {
                    _Title = "地球人你好！";
                }
                else
                {
                    _Title = "外星人你好，外星人再见！";
                }
                RaisePropertyChanged("_Title");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        internal virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
