namespace Domain.Models.StudentDto;

public class GStudentsWithGroupNameDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public int GroupId { get; set; }
    public string GroupName { get; set; }
}
