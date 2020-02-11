namespace TodoApp.Widgets.Lines
{
    public class BoldLineWidget : ILineWidget
    {
        public int TopLeft()
        {
            return '╔';
        }

        public int Horizontal()
        {
            return '═';
        }

        public int TopRight()
        {
            return '╗';
        }

        public int Vertical()
        {
            return '║';
        }

        public int BottomLeft()
        {
            return '╚';
        }

        public int BottomRight()
        {
            return '╝';
        }
    }
}