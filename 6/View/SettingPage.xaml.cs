using _6.Model;
using _6.ViewModel;
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

namespace _6.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
        }
        private Frame rootFrame { get; set; }
        private MainPageTheme Theme= MainPageThemeViewModel.GetMainPageTheme();

        private void MainTheme_Toggled(object sender, RoutedEventArgs e)
        {
            if(MainTheme.IsOn)
            {
                Theme.Theme = ElementTheme.Dark;
            }
            else
            {
                Theme.Theme = ElementTheme.Light;
            }
        }

        private void HeaderFontSize_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Theme.HeaderFontSize = (int)((Slider)sender).Value;
        }

        private void ContentFontSize_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Theme.ContentFontSize = (int)((Slider)sender).Value;
        }

        private void Location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Theme.Title = ((ComboBoxItem)(((ComboBox)sender).SelectedValue)).Content.ToString();
        }
    }
}
