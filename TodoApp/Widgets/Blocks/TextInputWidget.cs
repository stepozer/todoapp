using System;
using TodoApp.Models.Events;
using TodoApp.Widgets;
using TodoApp.Widgets.Lines;

namespace TodoApp.Blocks.Widgets
{
    public class TextInputWidget : BaseWidget
    {
        private string _text;
        private bool _selected;
        
        public TextInputWidget(string text)
        {
            Width = 10;
            Height = 3;
            OffsetY = 4;
            _text = text;
            _selected = false;
        }

        public override void Render()
        {
            Console.CursorTop = 4;
            Console.CursorLeft = 0;
            ILineWidget lineStyle;
            if (Focused)
            {
                lineStyle = new BoldLineWidget();
            }
            else
            {
                lineStyle = new NormalLineWidget();    
            }
            
            GuiWriteString(_text);
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteSymbol('>');
            GuiWriteSymbol('\n');
        }
        
        public override bool CanBeFocused()
        {
            return true;
        }

        public override BaseEventDto FetchEvent(ConsoleKeyInfo character, IWidget focusedWidget)
        {
            if (character.Key == ConsoleKey.Enter)
            {
                return new TaskCreateDto();
            }
            return base.FetchEvent(character, focusedWidget);
        }
    }
}