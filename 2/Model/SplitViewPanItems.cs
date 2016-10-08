using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _2.Model
{
    /// <summary>
    /// SplitView中Pan部分列表的项类型，包含图标和文字内容
    /// </summary>
    public class SplitViewPanItems
    {
        public SplitViewPanItems(Symbol Icon,string Content)
        {
            this._Icon = Icon;
            this._Content = Content;
        }
        private Symbol _Icon = new Symbol();
        public Symbol Icon
        {
            get
            {
                return _Icon;
            }
        }
        private string _Content;
        public string Content
        {
            get
            {
                return _Content;
            }
        }
    }
}
