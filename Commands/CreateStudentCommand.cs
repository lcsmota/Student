using MediatR;
using StudentCQRS.Models;

namespace StudentCQRS.Commands;

public class CreateStudentCommand : IRequest<Student>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Age { get; set; }

    public CreateStudentCommand(string name, string email, string address, int age)
    {
        Name = name;
        Email = email;
        Address = address;
        Age = age;
    }
}
