using RingoMedia.ModulesTask.Models;
using System.Net.Mail;
using System.Net;
using Hangfire;

namespace RingoMedia.ModulesTask.Services;

public class EmailReminderSchedulerService : IEmailReminderSchedulerService
{
    private readonly IBackgroundJobClient _backgroundJobClient;

    public EmailReminderSchedulerService(IBackgroundJobClient backgroundJobClient)
    {
        _backgroundJobClient = backgroundJobClient;

    }
    public void Schedule(Reminder reminder)
    {
        reminder.HangfireJobId = _backgroundJobClient.Schedule(() => SendEmailReminder(reminder), reminder.DateTime);
    }

    public void SendEmailReminder(Reminder reminder)
    {
        SmtpClient smtpClient = new SmtpClient("live.smtp.mailtrap.io", 587)
        {
            Credentials = new NetworkCredential("api", "3e2dad0017231b6ce3b645e577be43e6"),
            EnableSsl = true
        };
        smtpClient.Send("mailtrap@demomailtrap.com", reminder.RecipientEmail, reminder.Title, "Gentle Reminder!");
    }

    public void Cancel(Reminder reminder)
    {
        if (reminder.HangfireJobId != null)
        {
            _backgroundJobClient.Delete(reminder.HangfireJobId);
            reminder.HangfireJobId = null;
        }
    }

    public void Reschedule(Reminder reminder)
    {
        Cancel(reminder);
        Schedule(reminder);
    }
}

