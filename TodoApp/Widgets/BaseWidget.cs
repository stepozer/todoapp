using System.Collections.Generic;

namespace TodoApp.Widgets
{
    public class BaseWidget : IWidget
    {
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