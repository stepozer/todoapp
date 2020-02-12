using System;
using TodoApp.Controllers;
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
            repository.AddTask(new TaskListItemDto {Title = "Buy milk"});
            repository.AddTask(new TaskListItemDto {Title = "Catch butterfly", Completed = true});
            repository.AddTask(new TaskListItemDto {Title = "See waterfall"});
            repository.AddTask(new TaskListItemDto {Title = "Watch TV", Completed = true});

            var indexPage = new TasksListPageWidget(repository);
            var controller = new TasksController(indexPage, repository);
            
            while (true)
            {
                var character = Console.ReadKey();
                var focusedWidget = indexPage.FetchFocusedWidget();
                if (focusedWidget == null)
                {
                    continue;
                }
                var pageEvent = focusedWidget.FetchEvent(character, indexPage);    
                
                switch (pageEvent)
                {
                    case TaskDeleteDto dto:
                        controller.ActionDeleteTask(dto.Id);
                        break;
                    case SwitchFocusDto _:
                        controller.ActionSwitchFocus();
                        break;
                    case TaskToggleDto dto:
                        controller.ActionToggleTask(dto.Id);
                        break;
                    case ExitProgramDto dto:
                        return;
                }
            }
        }
    }
}