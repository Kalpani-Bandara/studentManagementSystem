using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers;

public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    // READ - Show all students
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students.ToListAsync();
        return View(students);
    }

    // CREATE - Show form
    public IActionResult Create()
    {
        return View();
    }

    // CREATE - Save to database
    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(student);
    }

    // EDIT - Show form with existing data
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // EDIT - Save changes
    [HttpPost]
    public async Task<IActionResult> Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(student);
    }

    // DELETE - Remove student
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}