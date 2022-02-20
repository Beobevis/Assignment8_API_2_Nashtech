using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment8_API_2.Models;

public class TaskUpdateModel
{
    
    [Required, MaxLength(100)]
    public string? Title{get;set;}
    public string? Description{get;set;}
    [DefaultValue(0)]
    public bool Completed {get;set;}

}