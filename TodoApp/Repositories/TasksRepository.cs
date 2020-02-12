using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp.Models
{
    public class TasksRepository
    {
        private List<TaskListItemDto> _tasks;
            
        public TasksRepository()
        {
            _tasks = new List<TaskListItemDto>();
        }
        
        public void AddTask(TaskListItemDto task)
        {
            _tasks.Add(task);
        }
        
        public void RemoveTask(string id)
        {
            _tasks.Remove(findTaskById(id));
        }
        
        public void ToggleTask(string id)
        {
            var task = findTaskById(id);
            task.Completed = !task.Completed;
        }

        public List<TaskListItemDto> All()
        {
            return _tasks;
        }

        private TaskListItemDto findTaskById(string id)
        {
            return _tasks.Single(task => task.Id == id);
        }
    }
}