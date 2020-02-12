using System;
using TodoApp.Models;
using TodoApp.Models.Events;
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
            if (_task.Completed)
            {
                GuiWriteSymbol('▣'); 
            }
            else
            {
                GuiWriteSymbol(' ');
            }
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteString(_task.Title.PadRight(Width));
            GuiWriteSymbol(lineStyle.Vertical());
            GuiWriteSymbol('\n');
        }
        
        public override bool CanBeFocused()
        {
            return true;
        }        
        
        public override BaseEventDto FetchEvent(ConsoleKeyInfo character, IWidget focusedWidget)
        {
            if (character.Key == ConsoleKey.Delete || character.Key == ConsoleKey.Backspace)
            {
                return new TaskDeleteDto(_task.Id);
            }
            if (character.Key == ConsoleKey.Spacebar)
            {
                return new TaskToggleDto(_task.Id);
            }
            return base.FetchEvent(character, focusedWidget);
        }
    }
}