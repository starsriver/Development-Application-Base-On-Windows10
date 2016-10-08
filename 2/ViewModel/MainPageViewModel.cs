using _2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
namespace _2.ViewModel
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            _Header = "视图切换与语义缩放";
            _ToggleButtonIsChecked = false;
            _SplitViewPanItemsCollection.Add(new SplitViewPanItems(Symbol.People, "People"));
            _SplitViewPanItemsCollection.Add(new SplitViewPanItems(Symbol.Document, "Document"));
            _SplitViewPanItemsCollection.Add(new SplitViewPanItems(Symbol.Video, "Video"));
            _SplitViewPanItemsCollection.Add(new SplitViewPanItems(Symbol.Download, "Download"));
            _SplitViewPanItemsCollection.Add(new SplitViewPanItems(Symbol.Pictures, "Pictures"));
            _SplitViewPanItemsCollection.Add(new SplitViewPanItems(Symbol.Audio, "Audio"));
            _SplitViewPanItemsCollection.Add(new SplitViewPanItems(Symbol.Camera, "Camera"));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 1", new Uri("ms-appx:///Assets/ExamplePicture1.jpg")));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 2", new Uri("ms-appx:///Assets/ExamplePicture2.jpg")));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 3", new Uri("ms-appx:///Assets/ExamplePicture3.jpg")));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 4", new Uri("ms-appx:///Assets/ExamplePicture4.jpg")));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 5", new Uri("ms-appx:///Assets/ExamplePicture1.jpg")));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 6", new Uri("ms-appx:///Assets/ExamplePicture2.jpg")));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 7", new Uri("ms-appx:///Assets/ExamplePicture3.jpg")));
            _SemanticZoomCollection.Add(new SemanticZoomDataSource("TestImage 8", new Uri("ms-appx:///Assets/ExamplePicture4.jpg")));
        }
        private string _Header { get; set; }
        public string Header
        {
            get
            {
                return _Header;
            }
        }
        private ObservableCollection<SplitViewPanItems> _SplitViewPanItemsCollection = new ObservableCollection<SplitViewPanItems>();

        public ObservableCollection<SplitViewPanItems> SplitViewPanItemsCollection
        {
            get
            {
                return _SplitViewPanItemsCollection;
            }
        }
        private ObservableCollection<SemanticZoomDataSource> _SemanticZoomCollection = new ObservableCollection<SemanticZoomDataSource>();
        public ObservableCollection<SemanticZoomDataSource> SemanticZoomCollection
        {
            get
            {
                return _SemanticZoomCollection;
            }
        }
        private bool _ToggleButtonIsChecked { get; set; }
        public bool ToggleButtonIsChecked
        {
            get
            {
                return _ToggleButtonIsChecked;
            }
            set
            {
                if(_ToggleButtonIsChecked!=value)
                {
                    _ToggleButtonIsChecked = value;
                    RaisePropertyChanged("ToggleButtonIsChecked");
                }
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
