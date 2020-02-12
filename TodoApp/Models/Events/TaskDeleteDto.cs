namespace TodoApp.Models.Events
{
    public class TaskDeleteDto : BaseEventDto
    {
        public string Id { get; set; }
        
        public TaskDeleteDto(string id)
        {
            Id = id;
        }
    }
}