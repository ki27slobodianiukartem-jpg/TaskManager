using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateTaskUseCase
{
    private readonly ITaskRepository _repository;

    public CreateTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public TaskItem Execute(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Назва завдання не може бути порожньою.");

        var all = _repository.GetAll();
        var task = new TaskItem
        {
            Id = all.Count == 0 ? 1 : all.Max(t => t.Id) + 1,
            Title = title.Trim()
        };
        _repository.Add(task);
        return task;
    }
}