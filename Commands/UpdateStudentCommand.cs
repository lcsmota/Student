using MediatR;
using StudentCQRS.Models;

namespace StudentCQRS.Commands;

public class UpdateStudentCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Age { get; set; }

    public UpdateStudentCommand(int id, string name, string email, string address, int age)
    {
        Id = id;
        Name = name;
        Email = email;
        Address = address;
        Age = age;
    }
}
