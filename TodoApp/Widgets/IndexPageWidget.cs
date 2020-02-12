using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;

namespace TodoApp.Widgets
{
    public class IndexPageWidget : BaseWidget  
    {
        public IndexPageWidget(TasksRepository repository)
        {
            _children = new List<IWidget>();
            AddChild(new ButtonWidget("Add task"));
            AddChild(new ButtonWidget("Exit"));
            AddChild(new TaskListWidget(repository));
            
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