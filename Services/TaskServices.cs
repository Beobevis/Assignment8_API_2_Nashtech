using Assignment8_API_2.Models;
using Task = Assignment8_API_2.Models.Task;
namespace Assignment8_API_2.Services;

public class TaskServices : ITaskServices
{
    private static readonly List<Task> _data = new List<Task>();
    public List<Task> GetAll()
    {
        return _data;
    }


    public Task? GetOne(Guid id)
    {
        return _data.FirstOrDefault(d => d.Id == id);
    }

    public Task Add(Task task)
    {
        _data.Add(task);

        return task;
    }
    public void Delete(Guid id)
    {

    }

    public Task? Edit(Task task)
    {
        var currentTask = _data.FirstOrDefault(d => d.Id == task.Id);
        if (currentTask == null) return null;

        currentTask.Title = task.Title;
        currentTask.Description = task.Description;
        currentTask.Completed = task.Completed;

        return currentTask;
    }

    public void Remove(Guid id)
    {
        var currentTask = _data.FirstOrDefault(d => d.Id == id);
        if (currentTask != null) _data.Remove(currentTask);
    }

    public List<Task> Add(List<Task> tasks)
    {
        _data.AddRange(tasks);
        return tasks;
    }

    public void Remove(List<Guid> ids)
    {
        
            _data.RemoveAll(d=>ids.Contains(d.Id));
        
    }
    public bool Exist(Guid id){
        return _data.Any(d=>d.Id == id);
    }
}