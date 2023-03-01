using MediatR;
using StudentCQRS.Commands;
using StudentCQRS.Repositories.Interfaces;

namespace StudentCQRS.Handlers;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IStudentRepository _studentRepo;

    public DeleteStudentHandler(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepo.GetStudentByIdAsync(request.Id);

        if (student is null) return default;

        return await _studentRepo.DeleteStudentAsync(student.Id);
    }
}
