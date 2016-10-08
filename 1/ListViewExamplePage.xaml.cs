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
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace _1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ListViewExamplePage : Page
    {
        public ListViewExamplePage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            ViewModel = new ListViewExampleViewModel();
        }
        private Frame rootFrame { get; set; }
        public ListViewExampleViewModel ViewModel { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (rootFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listview = (ListView)sender;
            if (listview == null)
            {
                return;
            }
            ListViewExampleDataSource tempDataSource = listview.SelectedItem as ListViewExampleDataSource;
            if(tempDataSource==null)
            {
                return;
            }
            rootFrame.Navigate(typeof(ContentsPage), tempDataSource);
        }
    }
    public class ListViewExampleDataSource
    {
        public ListViewExampleDataSource(Symbol Icon,string Title,string Content)
        {
            this.Icon = Icon;
            this.Title = Title;
            this.Content = Content;
        }
        public Symbol Icon { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public class ListViewExampleViewModel
    {
        public ListViewExampleViewModel()
        {
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.Audio,"Audio Icon","This Is Audio Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.Bullets, "Bullets Icon", "This Is Bullets Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.Video, "Video Icon", "This Is Video Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _ListViewExampleDataSourceCollection.Add(new ListViewExampleDataSource(Symbol.People, "People Icon", "This Is People Icon"));
            _Header = "This is used to show ListView";
            _Title = "ListView Example";
        }
        private string _Title;
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
        private ObservableCollection<ListViewExampleDataSource> _ListViewExampleDataSourceCollection = new ObservableCollection<ListViewExampleDataSource>();
        public ObservableCollection<ListViewExampleDataSource> ListViewExampleDataSourceCollection
        {
            get
            {
                return _ListViewExampleDataSourceCollection;
            }
        }
    }

}
