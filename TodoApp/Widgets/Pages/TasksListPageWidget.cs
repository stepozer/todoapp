using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Blocks.Widgets;
using TodoApp.Models;
using TodoApp.Models.Events;

namespace TodoApp.Widgets
{
    public class TasksListPageWidget : BaseWidget  
    {
        public TasksListPageWidget(TasksRepository repository)
        {
            _children = new List<IWidget>();
            AddChild(new ButtonWidget("Add task", new RedirectToCreateTaskDto()));
            AddChild(new ButtonWidget("Exit", new ExitProgramDto()));
            
            int currentX = Console.CursorLeft;
            int currentY = Console.CursorTop;
            foreach (var widget in _children)
            {
                widget.OffsetX = currentX;
                currentX += widget.Width + 2;
                widget.OffsetY = currentY;
            }
            
            AddChild(new TaskListWidget(repository));
        }
    }
}