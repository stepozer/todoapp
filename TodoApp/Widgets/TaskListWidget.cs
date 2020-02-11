using System;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Widgets
{
    public class TaskListWidget : BaseWidget
    {
        private List<TaskListItemDto> _tasks;
        
        public TaskListWidget(List<TaskListItemDto> tasks)
        {
            Console.CursorTop = OffsetX;
            Console.CursorLeft = OffsetY;
            
            _tasks = tasks;
            _children = new List<IWidget>();
            foreach (var task in _tasks)
            {
                _children.Add(new TaskListItemWidget(task));
            }
        }
    }
}