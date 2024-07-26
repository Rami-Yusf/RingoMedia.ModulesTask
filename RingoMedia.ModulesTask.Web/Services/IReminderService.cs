using RingoMedia.ModulesTask.Models;

namespace RingoMedia.ModulesTask.Services
{
    public interface IReminderService
    {
        List<Reminder> GetAll();
        Reminder GetById(int id);
        void Add(Reminder reminder);
        void Delete(int id);
        void Update(Reminder reminder);
        bool Exists(int id);
    }
}