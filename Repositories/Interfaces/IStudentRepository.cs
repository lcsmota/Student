using System.Linq.Expressions;
using StudentCQRS.Models;

namespace StudentCQRS.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<List<Student>> GetStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task<Student> InsertStudentAsync(Student student);
    Task<int> UpdateStudentAsync(Student student);
    Task<int> DeleteStudentAsync(int id);
}
