using System;
using TodoApp.Models;
using TodoApp.Models.Events;
using TodoApp.Widgets;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new TasksRepository();
            repository.AddTask(new TaskListItemDto {Title = "Some 1"});
            repository.AddTask(new TaskListItemDto {Title = "Some 2", Completed = true});
            repository.AddTask(new TaskListItemDto {Title = "Some 3"});
            repository.AddTask(new TaskListItemDto {Title = "Some 4", Completed = true});

            Console.Clear();
            Console.WriteLine("Todo App");
            var indexPage = new IndexPageWidget(repository);
            indexPage.InitializeFocus();
            indexPage.Render();

            while (true)
            {
                var character = Console.ReadKey();
                var focusedWidget = indexPage.FetchFocusedWidget();
                if (focusedWidget == null)
                {
                    continue;
                }
                var pageEvent = focusedWidget.FetchEvent(character, indexPage);    
                
                if (pageEvent is SwitchFocusDto)
                {
                    var status = new FocusStatusDto();
                    indexPage.SwitchFocus(status);
                    if (!status.Set)
                    {
                        status.Found = true;
                        indexPage.SwitchFocus(status);
                    }
                    indexPage.Render();
                    continue;
                }
                if (pageEvent is ExitProgramDto)
                {
                    break;
                }

                if (pageEvent is TaskToggleDto)
                {
                    repository.ToggleTask(((TaskToggleDto) pageEvent).Id);
                    indexPage.Render();
                }

                if (pageEvent is TaskDeleteDto)
                {
                    Console.Clear();
                    repository.RemoveTask(((TaskDeleteDto) pageEvent).Id);
                    indexPage.Render();
                    
                    if (indexPage.FetchFocusedWidget() == null)
                    {
                        indexPage.SwitchFocus(new FocusStatusDto { Found = true, Set = false } );
                        indexPage.Render();
                    }
                }
            }
        }
    }
}