using System;
using TodoApp.Models;

namespace TodoApp.Widgets
{
    public interface IWidget
    {
        public void Render();
        public void FetchEvent(ConsoleKeyInfo character, EventDto pageEvent);
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }
        
        public bool Focused { get; set; }

        public bool CanBeFocused();

        public void InitializeFocus();
        
        public void SwitchFocus(FocusStatusDto status);
    }
}