using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace _9.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            rootFrame = Window.Current.Content as Frame;
            p1 = new BitmapImage(new Uri("ms-appx:///Assets/J20.jpg"));
            p2 = new BitmapImage(new Uri("ms-appx:///Assets/test.jpg"));
        }
        private Frame rootFrame { get; set; }
        private BitmapImage p1 { get; set; }
        private BitmapImage p2 { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void TestGesture_Holding(object sender, HoldingRoutedEventArgs e)
        {
            if ((string)TestGesture.Tag == "0")
            {
                TestGesture.Source = p2;
                TestGesture.Tag = "1";
            }
            else
            {
                TestGesture.Source = p1;
                TestGesture.Tag = "0";
            }
        }

        private void TestGesture_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            ImageTransform.CenterX = TestGesture.ActualWidth / 2;
            ImageTransform.CenterY = TestGesture.ActualHeight / 2;
            ImageTransform.TranslateX += e.Delta.Translation.X;
            ImageTransform.TranslateY += e.Delta.Translation.Y;
            ImageTransform.ScaleX *= e.Delta.Scale;
            ImageTransform.ScaleY *= e.Delta.Scale;
            ImageTransform.Rotation = e.Delta.Rotation * 180 / Math.PI;
            
        }

        private void TestPointer_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (null != rect)
            {
                rect.Width = 250;
                rect.Height = 150;
            }
        }

        private void TestPointer_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (null != rect)
            {
                rect.Width = 200;
                rect.Height = 100;
            }
        }

        private void TestPointer_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (rect != null)
            {
                rect.Width += 2;
                rect.Height += 2;
            }
        }

        private void TestPointer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (null != rect)
            {
                rect.Width = 200;
                rect.Height = 100;
            }
        }
    }
}
