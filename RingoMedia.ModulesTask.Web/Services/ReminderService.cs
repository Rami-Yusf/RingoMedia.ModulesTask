using RingoMedia.ModulesTask.Models;
using RingoMedia.ModulesTask.Services;

namespace RingoMedia.ModulesTask.Services;

public class ReminderService : IReminderService
{
    private readonly IEmailReminderSchedulerService _emailReminderSchedulerService;
    private readonly AppDbContext _db;

    public ReminderService(IEmailReminderSchedulerService emailReminderSchedulerService, AppDbContext appDbContext)
    {
        _emailReminderSchedulerService = emailReminderSchedulerService;
        _db = appDbContext;
    }
    public List<Reminder> GetAll()
    {
        return _db.Reminders.ToList();
    }
    public Reminder GetById(int id)
    {
        return _db.Reminders.Find(id);
    }
    public void Add(Reminder reminder)
    {
        _emailReminderSchedulerService.Schedule(reminder);
        _db.Reminders.Add(reminder);
        _db.SaveChanges();
    }

    public void Delete(int reminder)
    {
        var reminderToDelete = GetById(reminder);
        if (reminderToDelete == null) return;
        _emailReminderSchedulerService.Cancel(reminderToDelete);
        _db.Reminders.Remove(reminderToDelete);
        _db.SaveChanges();
    }

    public void Update(Reminder reminder)
    {
        _emailReminderSchedulerService.Reschedule(reminder);
        _db.Reminders.Update(reminder);
        _db.SaveChanges();
    }

    public bool Exists(int id)
    {
       return _db.Reminders.Any(e => e.Id == id);
    }
}

