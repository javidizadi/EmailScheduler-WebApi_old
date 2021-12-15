using System.ComponentModel.DataAnnotations;

namespace Email_Scheduler_WebApi.Models;

public class Error
{
    [Key] public int Id { get; set; }

    [Required] public string? Text { get; set; }
}