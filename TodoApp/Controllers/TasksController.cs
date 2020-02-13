using System;
using TodoApp.Models;
using TodoApp.Widgets;

namespace TodoApp.Controllers
{
    public class TasksController
    {
        private IWidget _view;
        private TasksRepository _repository;
        
        public TasksController(IWidget view, TasksRepository repository)
        {
            _view = view;
            _repository = repository;
            RenderView();
        }

        public void SetView(IWidget view)
        {
            _view = view;
            RenderView();
        }

        public IWidget CurrentView()
        {
            return _view;
        }

        public void ActionSwitchFocus()
        {
            var status = new FocusStatusDto();
            _view.SwitchFocus(status);
            if (!status.Set)
            {
                status.Found = true;
                _view.SwitchFocus(status);
            }
            Render();
        }

        public void ActionToggleTask(string id)
        {
            _repository.ToggleTask(id);
            _view.Render();
        }

        public void ActionCreateTask(string title)
        {
            _repository.AddTask(new TaskListItemDto { Title = title });
        }
        
        public void ActionDeleteTask(string id)
        {
            _repository.RemoveTask(id);
            Render();
                    
            if (_view.FetchFocusedWidget() == null)
            {
                _view.SwitchFocus(new FocusStatusDto { Found = true, Set = false } );
                Render();
            }
        } 

        private void Render()
        {
            Console.Clear();
            _view.Render();
        }
        
        private void RenderView()
        {
            _view.InitializeFocus();
            Render();
        }
    }
}