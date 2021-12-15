using System.ComponentModel.DataAnnotations;

namespace Email_Scheduler_WebApi.Models;

public class ScheduleError
{
    [Key] public int Id { get; set; }

    [Required] public EmailSchedule? Schedule { get; set; }

    [Required] public Error? Error { get; set; }
}