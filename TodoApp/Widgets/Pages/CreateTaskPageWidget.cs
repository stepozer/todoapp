using System;
using System.Collections.Generic;
using TodoApp.Blocks.Widgets;
using TodoApp.Models;
using TodoApp.Models.Events;

namespace TodoApp.Widgets
{
    public class CreateTaskPageWidget : BaseWidget
    {
        public CreateTaskPageWidget(TasksRepository repository)
        {
            _children = new List<IWidget>();
            AddChild(new ButtonWidget("Back", new RedirectToTasksListDto()));
            AddChild(new ButtonWidget("Exit", new ExitProgramDto()));
            AddChild(new TextInputWidget("Please enter task title:"));
            
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