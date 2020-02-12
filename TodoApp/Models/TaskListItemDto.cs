using System;

namespace TodoApp.Models
{
    public class TaskListItemDto
    {
        public string Id;
        public string Title;
        public DateTime CreatedAt;
        public bool Completed;

        public TaskListItemDto()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}