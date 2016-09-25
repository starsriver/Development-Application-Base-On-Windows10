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
    public sealed partial class GridViewExamplePage : Page
    {
        public GridViewExamplePage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            ViewModel = new GridViewExampleViewModel();
        }
        private Frame rootFrame { get; set; }
        public GridViewExampleViewModel ViewModel { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 设置显示导航栏后退按钮
            if (rootFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
    }
    public class GridViewExampleDataSource
    {
        public GridViewExampleDataSource(string Title,Uri ImageSourceUri)
        {
            this.Title = Title;
            this.PictureSource = new BitmapImage(ImageSourceUri);
        }
        public string Title { get; set; }
        public BitmapImage PictureSource { get; set; }
    }
    public class GridViewExampleViewModel
    {
        public GridViewExampleViewModel()
        {
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 1", new Uri("ms-appx:///Assets/ExamplePicture1.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 2", new Uri("ms-appx:///Assets/ExamplePicture2.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 3", new Uri("ms-appx:///Assets/ExamplePicture3.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 3", new Uri("ms-appx:///Assets/ExamplePicture4.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 4", new Uri("ms-appx:///Assets/ExamplePicture1.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 5", new Uri("ms-appx:///Assets/ExamplePicture2.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 6", new Uri("ms-appx:///Assets/ExamplePicture3.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 7", new Uri("ms-appx:///Assets/ExamplePicture4.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 8", new Uri("ms-appx:///Assets/ExamplePicture1.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 9", new Uri("ms-appx:///Assets/ExamplePicture2.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 10", new Uri("ms-appx:///Assets/ExamplePicture3.jpg")));
            _GridViewExampleDataSourceCollection.Add(new GridViewExampleDataSource("TestImage 11", new Uri("ms-appx:///Assets/ExamplePicture4.jpg")));
            _Title = "GridView Example";
            _Header = "This is used to show GridView";
        }
        private string _Title { get; set; }
        public string Title
        {
            get
            {
                return _Title;
            }
        }
        private string _Header { get; set; }
        public string Header
        {
            get
            {
                return _Header;
            }
        }
        private ObservableCollection<GridViewExampleDataSource> _GridViewExampleDataSourceCollection = new ObservableCollection<GridViewExampleDataSource>();
        public ObservableCollection<GridViewExampleDataSource> GridViewExampleDataSourceCollection
        {
            get
            {
                return _GridViewExampleDataSourceCollection;
            }
        }
    }
}
