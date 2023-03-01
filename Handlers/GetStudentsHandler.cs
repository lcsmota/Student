using MediatR;
using StudentCQRS.Models;
using StudentCQRS.Queries;
using StudentCQRS.Repositories.Interfaces;

namespace StudentCQRS.Handlers;

public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, List<Student>>
{
    private readonly IStudentRepository _studentRepo;

    public GetStudentsHandler(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return await _studentRepo.GetStudentsAsync();
    }
}
