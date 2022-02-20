using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment8_API_2.Services;
using Assignment8_API_2.Models;
using Task = Assignment8_API_2.Models.Task;
namespace Assignment8_API_2.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskServices _taskServices;

    public TaskController(ILogger<TaskController> logger, ITaskServices taskServices)
    {
        _logger = logger;
        _taskServices = taskServices;
    }

    [HttpGet(Name = "GetAllTasks")]
    public IEnumerable<Task> GetAll()
    {
        return _taskServices.GetAll().AsEnumerable();
    }
    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetOne(Guid id)
    {
        var task = _taskServices.GetOne(id);
        if (task == null) return NotFound();
        return new JsonResult(task);
    }

    [HttpPost]
    public Task Add(TaskCreateModel model)
    {
        var task = new Task
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
            Description = model.Description,
            Completed = false,
        };
        return _taskServices.Add(task);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult Edit(Guid id, TaskUpdateModel model)
    {
        var task = _taskServices.GetOne(id);
        if (task == null) return NotFound();

        task.Title = model.Title;
        task.Description = model.Description;
        task.Completed = false;

        var result = _taskServices.Edit(task);
        return new JsonResult(result);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult Remove(Guid id)
    {

        if (!_taskServices.Exist(id)) return NotFound();

        _taskServices.Remove(id);

        return Ok();
    }

    [HttpPost]
    [Route("mutltiple")]
    public List<Task> AddMulti(List<TaskCreateModel> models)
    {
        var tasks = new List<Task>();
        foreach(var model in models){
            tasks.Add(new Task{
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Completed = false
            });
        }
        return _taskServices.Add(tasks);
    }
    [HttpPost]
    [Route("delete-mutltiple")]
    public IActionResult DeleteMulti(List<Guid> ids)
    {
        _taskServices.Remove(ids);
        return Ok();
    }

}
