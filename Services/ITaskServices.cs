using System.Threading.Tasks;
using Task = Assignment8_API_2.Models.Task;
namespace Assignment8_API_2.Services;

public interface ITaskServices
{
    List<Task> GetAll();

    Task? GetOne(Guid id);

    Task Add(Task task);
    void Delete(Guid id);

    Task? Edit(Task task);

    void Remove(Guid id);

    List<Task> Add(List<Task> tasks);

    void Remove(List<Guid> ids);
    bool Exist(Guid id);
}