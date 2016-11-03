using _8.View;
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

namespace _8
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += PageBackRequested;
            rootFrame = Window.Current.Content as Frame;
            ContentFrame.Navigated += ContentFrameNavigated;
        }
        private Frame rootFrame { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ContentFrame.Navigate(typeof(HomePage));
        }
        private void PageBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (ContentFrame==null)
            {
                return;
            }
            if(ContentFrame.CanGoBack)
            {
                e.Handled = true;
                ContentFrame.GoBack();
            }
        }

        private void ContentFrameNavigated(object sender,NavigationEventArgs e)
        {
            /*
            if(ContentFrame.Content is Home)
            {
                HomeButton.IsEnabled = false;
            }
            else
            {
                HomeButton.IsEnabled = true;
            }
            if(ContentFrame.Content is CameraPage)
            {
                CameraButton.IsEnabled = false;
            }
            else
            {
                CameraButton.IsEnabled = true;
            }
            if (ContentFrame == null)
            {
                return;
            }
            */
            // 设置显示导航栏后退按钮
            if (ContentFrame.CanGoBack)
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
