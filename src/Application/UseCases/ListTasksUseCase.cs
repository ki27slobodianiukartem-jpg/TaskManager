using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class ListTasksUseCase
{
    private readonly ITaskRepository _repository;

    public ListTasksUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public List<TaskItem> Execute() => _repository.GetAll();
}