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
            indexPage.Render();
        }
    }
}