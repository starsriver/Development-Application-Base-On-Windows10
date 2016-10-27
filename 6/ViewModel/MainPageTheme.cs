using _6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.ViewModel
{
    public static class MainPageThemeViewModel
    {
        private static MainPageTheme PageTheme = new MainPageTheme(25, 15, Windows.UI.Xaml.ElementTheme.Light, "地球人");
        public static MainPageTheme GetMainPageTheme()
        {
            return PageTheme;
        }
    }
}
