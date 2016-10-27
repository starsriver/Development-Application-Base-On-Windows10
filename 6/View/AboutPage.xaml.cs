using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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

namespace _6.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            AboutText = new StringBuilder();
            AboutText.Append("\n\n\n");
            AboutText.Append("Development Application Base On Windows10\n");
            AboutText.Append("项目6：设置\n");
            AboutText.Append("由于设置协议已在UWP中移除\n");
            AboutText.Append("故采用UWP中建议的设置页面代替\n");
            AboutText.Append("顺带表达对微软这种始乱终弃做法的\n");
            AboutText.Append("强烈不满\n");
            AboutText.Append("吐槽者：StarsRiver\n");
            AboutText.Append("此项目GitHub地址：\n");
            AboutText.Append("https://github.com/starsriver/Development-Application-Base-On-Windows10 \n");
            AboutText.Append("PS:吐槽也蛮累人的");
        }
        private Frame rootFrame { get; set; }
        private StringBuilder AboutText { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            about.Text = AboutText.ToString();
        }
    }
}
