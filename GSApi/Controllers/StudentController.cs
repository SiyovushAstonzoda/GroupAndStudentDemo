using Domain.Models.StudentDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GSApi.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost("AddStudent")]
    public string AddStudent(AUStudentDto student)
    {
        return _studentService.AddStudent(student);
    }

    [HttpPut("UpdateStudent")]
    public string UpdateStudent(AUStudentDto student) 
    {
        return _studentService.UpdateStudent(student);
    }

    [HttpDelete("DeleteStudent")]
    public string DeleteStudent(int id) 
    {
        return _studentService.DeleteStudent(id);
    }

    [HttpGet("GetAllStudents")]
    public IEnumerable<GStudentDto> GetAllStudents()
    {
        return _studentService.GetAllStudents();
    }

    [HttpGet("GetStudentById")]
    public GStudentDto GetStudentById(int id)
    {
        return _studentService.GetStudentById(id);
    }

    [HttpGet("GetAllStudentsByGroupId")]
    public IEnumerable<GStudentsByGroupId> GetAllStudentsByGroupId(int id)
    {
        return _studentService.GetAllStudentsByGroupId(id);
    }

    [HttpGet("GetRandomStudent")]
    public GStudentDto GetRandomStudent()
    {
        return _studentService.GetRandomStudent();
    }

    [HttpGet("GetAllStudentsWithGroupName")]
    public IEnumerable<GStudentsWithGroupNameDto> GetAllStudentsWithGroupName()
    {
        return _studentService.GetAllStudentsWithGroupName();
    }
}
