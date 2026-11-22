using Domain.Interfaces;

namespace Application.UseCases;

public class CompleteTaskUseCase
{
    private readonly ITaskRepository _repository;

    public CompleteTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public void Execute(int id)
    {
        var task = _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Завдання з Id {id} не знайдено.");
        task.Complete();
        _repository.Update(task);
    }
}