using _2.ViewModel;
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

namespace _2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            // minWidth=500,minHeight=320
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            viewModel = new MainPageViewModel();
            //this.ActualWidth
            //SemanticZoomExample.ToggleActiveView
            SemanticZoomExample.IsZoomedInViewActive = true;
        }
        private Frame rootFrame { get; set; }
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
        public MainPageViewModel viewModel { get; set; }

        private void SemanticZoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            SemanticZoomExample.IsZoomedInViewActive = !SemanticZoomExample.IsZoomedInViewActive;
        }
    }
}
