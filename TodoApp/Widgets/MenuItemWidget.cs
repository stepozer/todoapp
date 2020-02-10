using System;
using System.Net.Mime;

namespace TodoApp.Widgets
{
    public class MenuItemWidget : BaseWidget
    {
        private string _text;
        private bool _selected;
        
        public MenuItemWidget(string text)
        {
            _text = text;
            _selected = false;
        }

        public override void Render()
        {
            Console.WriteLine(_text);
        }
    }
}