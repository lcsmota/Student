using MediatR;
using StudentCQRS.Models;

namespace StudentCQRS.Queries;

public class GetStudentByIdQuery : IRequest<Student>
{
    public int Id { get; set; }
}
