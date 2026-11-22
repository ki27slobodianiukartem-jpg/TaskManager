using Domain.Entities;

namespace Domain.Interfaces;

public interface ITaskRepository
{
    void Add(TaskItem task);
    TaskItem? GetById(int id);
    List<TaskItem> GetAll();
    void Update(TaskItem task);
}