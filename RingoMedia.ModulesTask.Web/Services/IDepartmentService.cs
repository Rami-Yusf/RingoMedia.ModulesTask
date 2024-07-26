using Microsoft.AspNetCore.Mvc.Rendering;
using RingoMedia.ModulesTask.Models;

namespace RingoMedia.ModulesTask.Services;

public interface IDepartmentService
{
    void Add(Department department);
    void Delete(int department);
    bool Exists(int id);
    List<Department> GetAll();
    Department GetById(int id);
    void Update(Department department);
    Department GetByIdWithSubsAndParents(int id);
    List<SelectListItem> GetDepartmentsSelectList(int exceptId = 0);
}
