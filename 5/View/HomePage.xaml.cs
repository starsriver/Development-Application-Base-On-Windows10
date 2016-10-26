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

namespace _5.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            //注册应用恢复事件
            Application.Current.Resuming += new EventHandler<Object>(HomePage_Resuming);
            rootFrame = Window.Current.Content as Frame;
        }
        private Frame rootFrame { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //导航到此页面时，显示指定的本地事件
            Windows.Storage.ApplicationDataContainer localTestData = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localTestData.Values != null)
            {
                testTextBlock.Text = (string)localTestData.Values["test"];
            }
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
        /// <summary>
        /// 应用恢复时调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomePage_Resuming(Object sender, Object e)
        {
            Windows.Storage.ApplicationDataContainer localTestData = Windows.Storage.ApplicationData.Current.LocalSettings;
            string testData = "";
            if (localTestData.Values["test"] != null)
            {
                testData = (string)localTestData.Values["test"];
            }
            testData += "应用于" + DateTime.Now.ToString() + "挂起后恢复\n";
            localTestData.Values["test"] = testData;
            testTextBlock.Text = (string)localTestData.Values["test"];
        }
    }
}
