using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;

namespace TodoApp.Widgets
{
    public class IndexPageWidget : BaseWidget  
    {
        public IndexPageWidget(List<TaskListItemDto> tasks)
        {
            _children = new List<IWidget>();
            _children.Add(new ButtonWidget("Add task"));
            _children.Add(new ButtonWidget("Exit"));
            _children.Add(new TaskListWidget(tasks));
            
            int currentX = Console.CursorLeft;
            int currentY = Console.CursorTop;
            foreach (var widget in _children)
            {
                widget.OffsetX = currentX;
                currentX += widget.Width + 2;
                widget.OffsetY = currentY;
            }
        }
    }
}