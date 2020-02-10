using System;
using TodoApp.Models;

namespace TodoApp.Widgets
{
    public class TaskListItemWidget : BaseWidget
    {
        private TaskListItemDto _task;
        
        public TaskListItemWidget(TaskListItemDto task)
        {
            _task = task;
        }
        
        public override void Render()
        {
            Console.WriteLine(_task.Title);
        }
    }
}