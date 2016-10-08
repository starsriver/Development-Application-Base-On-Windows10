using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace _2.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SemanticZoomDataSource
    {
        public SemanticZoomDataSource(string Title,Uri PictureUri)
        {
            this._Title = Title;
            this._PictureSource = new BitmapImage(PictureUri);
        }
        private string _Title { get; set; }
        public string Title
        {
            get
            {
                return _Title;
            }
        }
        private BitmapImage _PictureSource { get; set; }
        public BitmapImage PictureSource
        {
            get
            {
                return _PictureSource;
            }
        }

    }
}
