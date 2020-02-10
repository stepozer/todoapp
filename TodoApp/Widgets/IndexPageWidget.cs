using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Widgets
{
    public class IndexPageWidget : BaseWidget  
    {
        public IndexPageWidget(List<TaskListItemDto> tasks)
        {
            _children = new List<IWidget>();
            _children.Add(new MenuItemWidget("Add task"));
            _children.Add(new TaskListWidget(tasks));
        }
    }
}