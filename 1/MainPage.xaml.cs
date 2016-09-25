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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace _1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
        }
        private Frame rootFrame { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(rootFrame==null)
            {
                return;
            }
            if(btn.Tag.ToString()== "FlipViewExamplePage")
            {
                rootFrame.Navigate(typeof(FlipViewExamplePage));
                //OnNavigatedTo(typeof(GridViewExamplePage));
            }
            else if(btn.Tag.ToString() == "ListViewExamplePage")
            {
                rootFrame.Navigate(typeof(ListViewExamplePage));
            }
            else if (btn.Tag.ToString() == "GridViewExamplePage")
            {
                rootFrame.Navigate(typeof(GridViewExamplePage));
            }
            else
            {
                return;
            }
        }
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
}
