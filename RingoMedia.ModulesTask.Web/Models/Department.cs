using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RingoMedia.ModulesTask.Models;

public class Department : IValidatableObject
{
    public int Id { get; set; }
    [Display(Name = "Department Name")]
    public string Name { get; set; }
    [Display(Name = "Logo")]
    public string? LogoPath { get; set; }
    [NotMapped]
    [Display(Name = "Logo")]
    public IFormFile? LogoFile { get; set; }
    [Display(Name = "Parent Department")]
    public int? ParentDepartmentId { get; set; }
    public Department? ParentDepartment { get; set; }
    [Display(Name = "Sub Departments")]
    public ICollection<Department> SubDepartments { get; set; } = new HashSet<Department>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ParentDepartmentId == Id && Id > 0)
        {
            yield return new ValidationResult("Parent department cannot be itself", [nameof(ParentDepartmentId)]);
        }
    }
}

