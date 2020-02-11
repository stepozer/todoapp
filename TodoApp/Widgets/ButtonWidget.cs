using System;

namespace TodoApp.Widgets
{
    public class ButtonWidget : BaseWidget
    {
        private string _text;
        private bool _selected;
        
        public ButtonWidget(string text)
        {
            Width = 10;
            Height = 3;
            _text = text;
            _selected = false;
        }

        public override void Render()
        {
            int topleft = '┌';
            int hline = '─';
            int topright = '┐';
            int vline = '│';
            int bottomleft = '└';
            int bottomright = '┘';

            Console.CursorTop = OffsetY;
            Console.CursorLeft = OffsetX;

            Write(topleft);
            for (int i = 0; i < 10; i++)
            {
                Write(hline);
            }
            Write(topright);
            Write('\n');
            
            Write(vline);
            Console.Write(_text.PadRight(10));
            Write(vline);
            Write('\n');
            
            Write(bottomleft);
            for (int i = 0; i < 10; i++)
            {
                Write(hline);
            }
            Write(bottomright);
            Write('\n');
        }
        
        private void Write(int charcode)
        {
            Console.Write((char)charcode);
        }
        private void WriteLine(int charcode)
        {
            Console.WriteLine((char)charcode);
        }
    }
}