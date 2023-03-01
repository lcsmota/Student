using MediatR;
using StudentCQRS.Models;

namespace StudentCQRS.Commands;

public class DeleteStudentCommand : IRequest<int>
{
    public int Id { get; set; }
}
