using MediatR;
using StudentCQRS.Models;
using StudentCQRS.Queries;
using StudentCQRS.Repositories.Interfaces;

namespace StudentCQRS.Handlers;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
{
    private readonly IStudentRepository _studentRepo;

    public GetStudentByIdHandler(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _studentRepo.GetStudentByIdAsync(request.Id);
    }
}
