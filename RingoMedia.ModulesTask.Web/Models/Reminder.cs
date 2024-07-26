using RingoMedia.ModulesTask.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingoMedia.ModulesTask.Models;

public class Reminder
{
    public int Id { get; set; }
    public string Title { get; set; }
    [FutureDate]
    public DateTime DateTime { get; set; }
    [EmailAddress]
    [Display(Name = "Recipient Email Address")]
    public string RecipientEmail { get; set; }
    public string? HangfireJobId { get; set; }
}

