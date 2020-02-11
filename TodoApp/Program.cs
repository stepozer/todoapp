using System;
using TodoApp.Models;
using TodoApp.Widgets;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new TasksRepository();
            repository.AddTask(new TaskListItemDto {Title = "Some 1"});
            repository.AddTask(new TaskListItemDto {Title = "Some 2"});
            repository.AddTask(new TaskListItemDto {Title = "Some 3"});
            repository.AddTask(new TaskListItemDto {Title = "Some 4"});

            Console.WriteLine("Todo App");
            var indexPage = new IndexPageWidget(repository.All());
            indexPage.InitializeFocus();
            indexPage.Render();

            while (true)
            {
                var character = Console.ReadKey();

                if (character.Key == ConsoleKey.Tab)
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
                
                if (character.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}