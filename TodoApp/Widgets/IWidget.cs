namespace TodoApp.Widgets
{
    public interface IWidget
    {
        public void Render();
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }
    }
}