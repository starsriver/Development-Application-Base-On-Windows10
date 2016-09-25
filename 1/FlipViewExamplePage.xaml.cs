using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace _1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class FlipViewExamplePage : Page
    {
        public FlipViewExamplePage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            ViewModel = new FlipViewExampleViewModel();
        }
        public FlipViewExampleViewModel ViewModel { get; set; }
        private Frame rootFrame { get; set; }
        private void ChangeFlipViewOrientation(object sender, RoutedEventArgs e)
        {
            VirtualizingStackPanel FlipViewOrientation = (VirtualizingStackPanel)FindName("FlipViewOrientation");
            if (FlipViewOrientation == null)
            {
                return;
            }
            if (FlipViewOrientation.Orientation == Orientation.Vertical)
            {
                FlipViewOrientation.Orientation = Orientation.Horizontal;
            }
            else
            {
                FlipViewOrientation.Orientation = Orientation.Vertical;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(rootFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
    }
    public class FlipViewExampleDataSource
    {
        public FlipViewExampleDataSource(string Title, Uri ImageSourceUri)
        {
            this.Title = Title;
            this.PictureSource = new BitmapImage(ImageSourceUri);
        }
        public string Title { get; set; }
        public BitmapImage PictureSource { get; set; }
    }
    public class FlipViewExampleViewModel
    {
        private ObservableCollection<FlipViewExampleDataSource> _FlipViewExampleDataSourceCollection = new ObservableCollection<FlipViewExampleDataSource>();
        public ObservableCollection<FlipViewExampleDataSource> FlipViewExampleDataSourceCollection
        {
            get
            {
                return this._FlipViewExampleDataSourceCollection;
            }
        }
        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
        }
        public FlipViewExampleViewModel()
        {
            _FlipViewExampleDataSourceCollection.Add(new FlipViewExampleDataSource("TestImage 1", new Uri("ms-appx:///Assets/ExamplePicture1.jpg")));
            _FlipViewExampleDataSourceCollection.Add(new FlipViewExampleDataSource("TestImage 2", new Uri("ms-appx:///Assets/ExamplePicture2.jpg")));
            _FlipViewExampleDataSourceCollection.Add(new FlipViewExampleDataSource("TestImage 3", new Uri("ms-appx:///Assets/ExamplePicture3.jpg")));
            _FlipViewExampleDataSourceCollection.Add(new FlipViewExampleDataSource("TestImage 3", new Uri("ms-appx:///Assets/ExamplePicture4.jpg")));
            _Title = "FlipView Example";
        }
    }
}
