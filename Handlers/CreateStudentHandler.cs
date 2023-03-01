using MediatR;
using StudentCQRS.Commands;
using StudentCQRS.Models;
using StudentCQRS.Repositories.Interfaces;

namespace StudentCQRS.Handlers;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
{
    private readonly IStudentRepository _studentRepo;
    public CreateStudentHandler(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student()
        {
            Name = request.Name,
            Email = request.Email,
            Address = request.Address,
            Age = request.Age
        };

        return await _studentRepo.InsertStudentAsync(student);
    }
}
