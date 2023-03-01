using MediatR;
using StudentCQRS.Models;

namespace StudentCQRS.Queries;

public class GetStudentsQuery : IRequest<List<Student>>
{

}
