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

            var pageTasksList = new TasksListPageWidget(repository);
            var pageTasksCreate = new CreateTaskPageWidget(repository);
            var controller = new TasksController(pageTasksList, repository);
            string buffer = ""; 
            
            while (true)
            {
                var character = Console.ReadKey();
                
                var focusedWidget = controller.CurrentView().FetchFocusedWidget();
                if (focusedWidget == null)
                {
                    continue;
                }
                var pageEvent = focusedWidget.FetchEvent(character, controller.CurrentView());    
                
                switch (pageEvent)
                {
                    case TaskDeleteDto dto:
                        controller.ActionDeleteTask(dto.Id);
                        buffer = "";
                        break;
                    case SwitchFocusDto _:
                        controller.ActionSwitchFocus();
                        buffer = "";
                        break;
                    case TaskNewDto _:
                        controller.ActionSwitchFocus();
                        buffer = "";
                        break;
                    case TaskToggleDto dto:
                        controller.ActionToggleTask(dto.Id);
                        buffer = "";
                        break;
                    case RedirectToCreateTaskDto dto:
                        controller.SetView(pageTasksCreate);
                        controller.ActionSwitchFocus();
                        controller.ActionSwitchFocus();
                        buffer = "";
                        break;
                    case RedirectToTasksListDto dto:
                        controller.SetView(pageTasksList);
                        buffer = "";
                        break;
                    case TaskCreateDto _:
                        controller.ActionCreateTask(buffer);
                        controller.SetView(pageTasksList);
                        buffer = "";
                        break;
                    case ExitProgramDto dto:
                        return;
                    default:
                        buffer += character.KeyChar;
                        break;
                }
            }
        }
    }
}