using MediatR;
using StudentCQRS.Commands;
using StudentCQRS.Repositories.Interfaces;

namespace StudentCQRS.Handlers;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
{
    private readonly IStudentRepository _studentRepo;

    public UpdateStudentHandler(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepo.GetStudentByIdAsync(request.Id);

        if (student is null) return default;

        student.Name = request.Name;
        student.Email = request.Email;
        student.Address = request.Address;
        student.Age = request.Age;

        return await _studentRepo.UpdateStudentAsync(student);
    }
}
