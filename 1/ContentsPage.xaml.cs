using System;
using System.Collections.Generic;
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
    public sealed partial class ContentsPage : Page
    {
        public ContentsPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
        }
        private Frame rootFrame { get; set; }
        public ContentsPageViewModel viewModel { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListViewExampleDataSource dataSource = e.Parameter as ListViewExampleDataSource;
            if(dataSource==null)
            {
                return;
            }
            viewModel = new ContentsPageViewModel(dataSource);
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
    public class ContentsPageViewModel
    {
        public ContentsPageViewModel(ListViewExampleDataSource dataSource)
        {
            this._dataSource = dataSource;
        }
        private ListViewExampleDataSource _dataSource;
        public ListViewExampleDataSource dataSource
        {
            get
            {
                return _dataSource;
            }
        }
    }
}
