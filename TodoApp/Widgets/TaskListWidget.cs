using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;
using TodoApp.Models.Events;

namespace TodoApp.Widgets
{
    public class TaskListWidget : BaseWidget
    {
        private TasksRepository _repository;

        public TaskListWidget(TasksRepository repository)
        {
            _repository = repository;
            RefteshChildren();
        }

        public override void Render()
        {
            if (_children.Count != _repository.All().Count)
            {
                RefteshChildren();
                if (_children.Count > 0)
                {
                    _children.First().Focused = true;
                }
            }
            base.Render();
        }
        
        private void RefteshChildren()
        {
            _children = new List<IWidget>();
            foreach (var task in _repository.All())
            {
                AddChild(new TaskListItemWidget(task));
            }
            
            int currentX = Console.CursorLeft;
            int currentY = 4;
            foreach (var widget in _children)
            {
                widget.OffsetX = currentX;
                widget.OffsetY = currentY;
                currentY += 1;
            }
        }   
    }
}