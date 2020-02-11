using System;
using TodoApp.Models;
using TodoApp.Widgets.Lines;

namespace TodoApp.Widgets
{
    public class TaskListItemWidget : BaseWidget
    {
        private TaskListItemDto _task;
        
        public TaskListItemWidget(TaskListItemDto task)
        {
            _task = task;
            Width = 20;
        }
        
        public override void Render()
        {
            ILineWidget lineStyle;
            if (Focused)
            {
                lineStyle = new BoldLineWidget();
            }
            else
            {
                lineStyle = new NormalLineWidget();    
            }
            
            GuiStartWidget();

            GuiStartWidgetLine();
            
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteSymbol(' ');
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteString(_task.Title.PadRight(Width));
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteSymbol('\n');
        }
        
        public override bool CanBeFocused()
        {
            return true;
        }        
    }
}