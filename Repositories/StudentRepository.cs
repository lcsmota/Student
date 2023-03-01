using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StudentCQRS.Data;
using StudentCQRS.Models;
using StudentCQRS.Repositories.Interfaces;

namespace StudentCQRS.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _context;

    public StudentRepository(StudentDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _context.Students
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return await _context.Students
            .AsNoTracking()
            .Where(e => e.Id.Equals(id))
            .FirstOrDefaultAsync();
    }

    public async Task<Student> InsertStudentAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<int> UpdateStudentAsync(Student student)
    {
        _context.Students.Update(student);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteStudentAsync(int id)
    {
        var studentDb = await _context.Students.Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();

        _context.Students.Remove(studentDb);

        return await _context.SaveChangesAsync();
    }
}
