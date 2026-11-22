using System.Text.Json;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class JsonTaskRepository : ITaskRepository
{
    private readonly string _filePath;

    public JsonTaskRepository(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(TaskItem task)
    {
        var tasks = Load();
        tasks.Add(task);
        Save(tasks);
    }

    public TaskItem? GetById(int id) => Load().FirstOrDefault(t => t.Id == id);

    public List<TaskItem> GetAll() => Load();

    public void Update(TaskItem task)
    {
        var tasks = Load();
        var index = tasks.FindIndex(t => t.Id == task.Id);
        if (index < 0)
            throw new KeyNotFoundException($"Завдання з Id {task.Id} не знайдено.");
        tasks[index] = task;
        Save(tasks);
    }

    private List<TaskItem> Load()
    {
        if (!File.Exists(_filePath))
            return new List<TaskItem>();
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    private void Save(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}