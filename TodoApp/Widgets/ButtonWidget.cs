using System;
using TodoApp.Models;
using TodoApp.Widgets.Lines;

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
            ILineWidget lineStyle;
            if (Focused)
            {
                lineStyle = new BoldLineWidget();
            }
            else
            {
                lineStyle = new NormalLineWidget();    
            }
            
            GuiStartWidget();

            GuiStartWidgetLine();
            GuiWriteSymbol(lineStyle.TopLeft());
            for (int i = 0; i < Width; i++)
            {
                GuiWriteSymbol(lineStyle.Horizontal());
            }
            GuiWriteSymbol(lineStyle.TopRight());
            GuiWriteSymbol('\n');
            
            GuiStartWidgetLine();
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteString(_text.PadRight(Width));
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteSymbol('\n');
            
            GuiStartWidgetLine();
            GuiWriteSymbol(lineStyle.BottomLeft());
            for (int i = 0; i < Width; i++)
            {
                GuiWriteSymbol(lineStyle.Horizontal());
            }
            GuiWriteSymbol(lineStyle.BottomRight());
            GuiWriteSymbol('\n');
        }
        
        public override bool CanBeFocused()
        {
            return true;
        }

        public override void FetchEvent(ConsoleKeyInfo character, EventDto pageEvent, IWidget focusedWidget)
        {
            if (character.Key == ConsoleKey.Enter)
            {
                pageEvent.name = EventDto.EventExit;
            }
        }
    }
}