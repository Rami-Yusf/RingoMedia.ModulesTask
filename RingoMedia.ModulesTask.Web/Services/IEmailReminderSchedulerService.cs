using RingoMedia.ModulesTask.Models;

namespace RingoMedia.ModulesTask.Services
{
    public interface IEmailReminderSchedulerService
    {
        void Cancel(Reminder reminder);
        void Reschedule(Reminder reminder);
        void Schedule(Reminder reminder);
        void SendEmailReminder(Reminder reminder);
    }
}