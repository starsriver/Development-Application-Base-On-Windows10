using NotificationsExtensions;
using NotificationsExtensions.Tiles;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace _7.View
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

        private async void CreateTile_Click(object sender, RoutedEventArgs e)
        {
            await CreatTile();
        }
        private async Task CreatTile()
        {
            string TileID = "SecondTile";
            string DisplayName = "磁贴";
            string Args = string.Format("Click @ {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            Uri TileImageUrl = new Uri("ms-appx:///Assets/TileImage1.png");
            TileSize UserTileSize = TileSize.Square150x150;
            SecondaryTile Tile = new SecondaryTile(TileID, DisplayName, Args, TileImageUrl, UserTileSize);
            Tile.VisualElements.ShowNameOnSquare150x150Logo = true;
            if (await Tile.RequestCreateAsync())
            {
                var doc = this.GetToastTemplete();
                var notification = new ToastNotification(doc);
                ToastNotificationManager.CreateToastNotifier().Show(notification);
            }
        }

        private void UpdateAllTile()
        {
            string from = "From: local host";
            string subject = "debug";
            string body = "测试磁贴更新";
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = from
                                },
                                new AdaptiveText()
                                {
                                    Text = subject,
                                    HintStyle= AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = body,
                                    HintStyle= AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = from,
                                    HintStyle= AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = subject,
                                    HintStyle= AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = body,
                                    HintStyle= AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    }
                }
            };
            TileNotification notification = new TileNotification(content.GetXml());
            //TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
            if (SecondaryTile.Exists("SecondTile"))
            {
                TileUpdater updater = TileUpdateManager.CreateTileUpdaterForSecondaryTile("SecondTile");
                updater.Update(notification);
            }
        }

        private XmlDocument GetToastTemplete()
        {
            string ToastXml = @"
                        <toast>
                            <visual>    
                                <binding template=""ToastGeneric"">
                                    <text> 来自 7 的通知 </text>
                                    <text> 辅助磁贴已创建 </text>
                                </binding>
                            </visual>
                        </toast> ";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ToastXml);
            return doc;
        }

        private void UpdateTile_Click(object sender, RoutedEventArgs e)
        {
            UpdateAllTile();
        }
    }
}
