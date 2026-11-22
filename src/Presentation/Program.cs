using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Repositories;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

// Збирання залежностей (Dependency Injection)
ITaskRepository repository = new JsonTaskRepository("tasks.json");
var createTask = new CreateTaskUseCase(repository);
var completeTask = new CompleteTaskUseCase(repository);
var listTasks = new ListTasksUseCase(repository);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1 - Додати завдання");
    Console.WriteLine("2 - Показати завдання");
    Console.WriteLine("3 - Завершити завдання");
    Console.WriteLine("0 - Вийти");
    Console.Write("Ваш вибір: ");
    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Назва: ");
                var task = createTask.Execute(Console.ReadLine() ?? "");
                Console.WriteLine($"Додано завдання #{task.Id}");
                break;
            case "2":
                foreach (var t in listTasks.Execute())
                    Console.WriteLine($"{t.Id}. [{(t.IsCompleted ? "x" : " ")}] {t.Title}");
                break;
            case "3":
                Console.Write("Id завдання: ");
                completeTask.Execute(int.Parse(Console.ReadLine() ?? ""));
                Console.WriteLine("Завдання виконано.");
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Невідомий пункт меню.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Помилка: {ex.Message}");
    }
}