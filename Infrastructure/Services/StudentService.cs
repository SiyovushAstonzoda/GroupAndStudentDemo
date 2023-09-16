using Dapper;
using Domain.Models.StudentDto;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _context;

    public StudentService(DataContext context)
    {
        _context = context;
    }

    //Add Student
    public string AddStudent(AUStudentDto student)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " insert into students(firstname, lastname, phone, groupid) " +
                          " values(@FirstName, @LastName, @Phone, @GroupId);";

            var result = conn.Execute(command, new
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Phone = student.Phone,
                GroupId = student.GroupId,
            });

            return $"Successfully added: {result}";
        }
    }

    //Update Student
    public string UpdateStudent(AUStudentDto student)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " update students " +
                          " set firstname = @FirstName, lastname = @LastName, phone = @Phone, groupid = @GroupId " +
                          " where id = @Id;";

            var result = conn.Execute(command, new
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Phone = student.Phone,
                GroupId = student.GroupId,
                Id = student.Id
            });

            return $"Successfully updated: {result}";
        }
    }

    //Delete Student
    public string DeleteStudent(int id)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " delete from students " +
                          " where id = @Id;";

            var result = conn.Execute(command, new
            {
                Id = id
            });

            return $"Successfully deleted: {result}";
        }
    }

    //Get All Students
    public IEnumerable<GStudentDto> GetAllStudents()
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * " +
                          " from students;";

            var result = conn.Query<GStudentDto>(command);

            return result;
        }
    }

    //Get Student by Id
    public GStudentDto GetStudentById(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * " +
                          " from students " +
                          " where id = @Id;";

            var result = conn.QuerySingleOrDefault<GStudentDto>(command, new
            {
                Id = id
            });

            return result;
        }
    }

    //Get all Students by GroupId
    public IEnumerable<GStudentsByGroupId> GetAllStudentsByGroupId(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select g.groupname, concat(s.firstname, ' ', s.lastname) as fullname " +
                          " from students as s " +
                          " join groups as g " +
                          " on s.groupid = g.id " +
                          " where g.id = @Id " +
                          " order by fullname;";

            var result = conn.Query<GStudentsByGroupId>(command, new
            {
                Id = id
            });

            return result;
        }
    }

    //Get a random Student
    public GStudentDto GetRandomStudent()
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * from students " +
                          " order by random() " +
                          " limit 1;";

            var result = conn.QuerySingleOrDefault<GStudentDto>(command);

            return result;
        }    
    }

    //Get all Students with GroupName
    public IEnumerable<GStudentsWithGroupNameDto> GetAllStudentsWithGroupName()
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select s.id, s.firstname, s.lastname, s.phone, s.groupid, g.groupname " +
                          " from students as s " +
                          " join groups as g " +
                          " on s.groupid = g.id " +
                          " order by g.groupname;";

            var result = conn.Query<GStudentsWithGroupNameDto>(command);

            return result;
        }
    }
}
