using System;

namespace TodoApp.Models
{
    public class TaskListItemDto
    {
        public string Id;
        public string Title;
        public DateTime CreatedAt;
        public DateTime CompletedAt;

        public TaskListItemDto()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}