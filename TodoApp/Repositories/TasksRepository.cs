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
        
        public void RemoveTask(TaskListItemDto task)
        {
            _tasks.Remove(findTaskById(task.Id));
        }
        
        public void EditTask(TaskListItemDto task)
        {
            var currentTask = findTaskById(task.Id);
            currentTask.Title = task.Title;
            currentTask.CompletedAt = task.CompletedAt;
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