using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Контракт сховища завдань. Реалізується в Infrastructure-шарі.
/// </summary>
public interface ITaskRepository
{
    /// <summary>Додає нове завдання.</summary>
    void Add(TaskItem task);

    /// <summary>Повертає завдання за Id або null, якщо не знайдено.</summary>
    TaskItem? GetById(int id);

    /// <summary>Повертає всі завдання.</summary>
    List<TaskItem> GetAll();

    /// <summary>Оновлює існуюче завдання.</summary>
    void Update(TaskItem task);
}