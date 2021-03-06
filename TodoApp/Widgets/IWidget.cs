using System;
using TodoApp.Models;
using TodoApp.Models.Events;

namespace TodoApp.Widgets
{
    public interface IWidget
    {
        public void Render();
        public BaseEventDto FetchEvent(ConsoleKeyInfo character, IWidget focusedWidget);
        public IWidget FetchFocusedWidget();
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Focused { get; set; }
        public bool CanBeFocused();
        public void InitializeFocus();
        public void SwitchFocus(FocusStatusDto status);
        public IWidget Parent { get; set; }
    }
}