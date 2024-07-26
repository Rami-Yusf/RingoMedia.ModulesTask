using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RingoMedia.ModulesTask.Models;
using RingoMedia.ModulesTask.Services;

namespace RingoMedia.ModulesTask.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(_departmentService.GetAll());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.GetByIdWithSubsAndParents(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
    
        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["ParentDepartmentId"] = _departmentService.GetDepartmentsSelectList();
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ParentDepartmentId,LogoFile")] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Add(department);
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["ParentDepartmentId"] = _departmentService.GetDepartmentsSelectList(); 
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
           

            ViewData["ParentDepartmentId"] = _departmentService.GetDepartmentsSelectList(id.Value);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LogoPath,ParentDepartmentId,LogoFile")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _departmentService.Update(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_departmentService.Exists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
     

            ViewData["ParentDepartmentId"] = _departmentService.GetDepartmentsSelectList(id);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _departmentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
