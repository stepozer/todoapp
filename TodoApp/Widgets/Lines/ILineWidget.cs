namespace TodoApp.Widgets.Lines
{
    interface ILineWidget
    {
        public int TopLeft();
        public int Horizontal();
        public int TopRight();
        public int Vertical();
        public int BottomLeft();
        public int BottomRight();
    }
}