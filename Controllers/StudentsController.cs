using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentCQRS.Commands;
using StudentCQRS.Models;
using StudentCQRS.Queries;

namespace StudentCQRS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Student>> GetStudentsAsync()
    {
        var student = await _mediator.Send(new GetStudentsQuery());

        return student;
    }

    [HttpGet("{id:int}")]
    public async Task<Student> GetStudentByIdAsync(int id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery() { Id = id });

        return student;
    }

    [HttpPost]
    public async Task<Student> InsertStudentAsync(Student student)
    {
        var result = await _mediator.Send(new CreateStudentCommand(
            student.Name,
            student.Email,
            student.Address,
            student.Age
        ));

        return result;
    }

    [HttpPut]
    public async Task<int> UpdateStudentAsync(Student student)
    {
        var result = await _mediator.Send(new UpdateStudentCommand(
            student.Id,
            student.Name,
            student.Email,
            student.Address,
            student.Age
        ));

        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<int> DeleteStudentAsync(int id)
    {
        return await _mediator.Send(new DeleteStudentCommand() { Id = id });
    }
}
