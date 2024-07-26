using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RingoMedia.ModulesTask.Models;
using RingoMedia.ModulesTask.Services;

namespace RingoMedia.ModulesTask.Services;


public class DepartmentService : IDepartmentService
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public DepartmentService(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
    {
        _db = appDbContext;
        _webHostEnvironment = webHostEnvironment;
    }
    public List<Department> GetAll()
    {
        return _db.Departments.ToList();
    }
    public Department GetById(int id)
    {
        return _db.Departments.Find(id);
    }
    public void Add(Department department)
    {
        _db.Departments.Add(department);
        _db.SaveChanges();
        SaveLogo(department);
    }

    private void SaveLogo(Department department)
    {
        if (department.LogoFile != null)
        {
            // Save Logo to wwwroot/department-logos
            string extension = Path.GetExtension(department.LogoFile.FileName).ToLower();
            department.LogoPath = $"/department-logos/{department.Id}{extension}";
            using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + department.LogoPath, FileMode.Create))
            {
                department.LogoFile.CopyTo(fileStream);
            }
            _db.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var DepartmentToDelete = GetById(id);
        if (DepartmentToDelete == null) return;
        _db.Departments.Remove(DepartmentToDelete);
        _db.SaveChanges();
    }

    public void Update(Department department)
    {
        SaveLogo(department);
        _db.Departments.Update(department);
        _db.SaveChanges();
    }

    public bool Exists(int id)
    {
        return _db.Departments.Any(e => e.Id == id);
    }
    public Department GetByIdWithSubsAndParents(int id)
    {
        var department = GetWithParents(id);
        _db.Entry(department).Collection(d => d.SubDepartments).Load();
        return department;
    }
    private Department GetWithParents(int id)
    {
        var department = GetById(id);
        if (department?.ParentDepartmentId != null)
        {
            department.ParentDepartment = GetWithParents(department.ParentDepartmentId.Value);
        }

        return department;
    }

    public List<SelectListItem> GetDepartmentsSelectList(int exceptId = 0)
    {
        var departmentsSelectList = new SelectList(_db.Departments.Where(d => d.Id != exceptId), "Id", "Name").ToList();
        departmentsSelectList.Insert(0, new SelectListItem("-- Select department --", ""));
        return departmentsSelectList;
    }
}
