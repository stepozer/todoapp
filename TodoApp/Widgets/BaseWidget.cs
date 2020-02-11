using System.Collections.Generic;

namespace TodoApp.Widgets
{
    public class BaseWidget : IWidget
    {
        public bool Focused { get; set; } = true;
        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        
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
    }
}