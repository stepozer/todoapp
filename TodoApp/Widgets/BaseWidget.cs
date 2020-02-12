using System;
using System.Collections.Generic;
using TodoApp.Models;
using TodoApp.Models.Events;

namespace TodoApp.Widgets
{
    public class BaseWidget : IWidget
    {
        public bool Focused { get; set; } = false;
        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public IWidget Parent { get; set; }

        protected List<IWidget> _children;
        

        public virtual void Render()
        {
            if (_children == null)
            {
                return;
            }
            
            foreach (var item in _children)
            {
                item.Render();
            }
        }

        public IWidget FetchFocusedWidget()
        {
            if (Focused)
            {
                return this;
            }

            if (_children != null)
            {
                foreach (var item in _children)
                {
                    var result = item.FetchFocusedWidget();

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        public virtual BaseEventDto FetchEvent(ConsoleKeyInfo character, IWidget focusedWidget)
        {
            if (character.Key == ConsoleKey.Tab)
            {
                return new SwitchFocusDto();
            }
            if (character.Key == ConsoleKey.Escape)
            {
                return new ExitProgramDto();
            }
            if (Parent != null)
            {
                return Parent.FetchEvent(character, focusedWidget);
            }
            else
            {
                return null;
            }
        }

        protected void GuiWriteSymbol(int charcode)
        {
            Console.Write((char)charcode);
        }
        
        protected void GuiWriteString(string text)
        {
            Console.Write(text);
        }

        protected void GuiStartWidget()
        {
            Console.CursorTop = OffsetY;
            Console.CursorLeft = OffsetX;
        }

        protected void GuiStartWidgetLine()
        {
            Console.CursorLeft = OffsetX;
        }

        protected void AddChild(IWidget widget)
        {
            _children.Add(widget);
            widget.Parent = this;
        }

        public virtual bool CanBeFocused()
        {
            return false;
        }

        public void InitializeFocus()
        {
            if (_children == null)
            {
                return;
            }
            foreach (var item in _children)
            {
                if (item.CanBeFocused())
                {
                    item.Focused = true;
                    return;
                }
                else
                {
                    item.InitializeFocus();
                }
            }
        }

        public void SwitchFocus(FocusStatusDto status)
        {
            if (_children == null)
            {
                return;
            }
            foreach (var item in _children)
            {
                if (status.Found && item.CanBeFocused())
                {
                    item.Focused = true;
                    status.Set = true;
                    return;
                }
                else
                {
                    if (item.Focused)
                    {
                        item.Focused = false;
                        status.Found = true;
                    }
                    item.SwitchFocus(status);
                }
            }
        }
    }
}