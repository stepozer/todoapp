namespace TodoApp.Models.Events
{
    public class TaskToggleDto : BaseEventDto
    {
        public string Id { get; set; }
    
        public TaskToggleDto(string id)
        {
            Id = id;
        }
    }
}