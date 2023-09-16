using Dapper;
using Domain.Models.GroupDto;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class GroupService
{
    public readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }

    //Add Group
    public string AddGroup(AUGroupDto group)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " insert into groups (groupname, title) " +
                          " values (@GroupName, @Title);";

            var result = conn.Execute(command, new
            {
                GroupName = group.GroupName,
                Title = group.Title,
            });

            return $"Successfully added: {result}";
        }
    }

    //Update Group
    public string UpdateGroup(AUGroupDto group)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " update groups " +
                          " set groupname = @GroupName, title = @Title " +
                          " where id = @Id;";

            var result = conn.Execute(command, new
            {
                GroupName = group.GroupName,
                Title = group.Title,
                Id = group.Id
            });

            return $"Successfully updated: {result}";
        }
    }

    //Delete Group
    public string DeleteGroup(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " delete from groups " +
                          " where id = @Id;";

            var result = conn.Execute(command, new
            {
                Id = id
            });

            return $"Successfully deleted: {result}";
        }
    }

    //Get all Groups
    public IEnumerable<GGroupDto> GetAllGroups()
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * " +
                          " from groups;";

            var result = conn.Query<GGroupDto>(command);

            return result;
        }
    }

    //Get Group by Id
    public GGroupDto GetGroupById(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * " +
                        " from groups " +
                        " where id = @Id;";

            var result = conn.QueryFirstOrDefault<GGroupDto>(command, new
            { 
                Id = id
            });

            return result;
        }
    }

    //Get all Groups with Students
    public IEnumerable<GWithSDto> GetAllGroupsWithStudents()
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select g.groupname, concat(s.firstname, ' ', s.lastname) as fullname " +
                          " from groups as g " +
                          " left join students as s " +
                          " on g.id = s.groupid " +
                          " order by g.groupname;";

            var result = conn.Query<GWithSDto>(command);

            return result;
        }
    }

    //Get Group by Id with Students
    public IEnumerable<GWithSDto> GetGroupByIdWithStudents(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select g.groupname, concat(firstname, ' ', lastname) as fullname " +
                          " from groups as g " +
                          " left join students as s " +
                          " on g.id = s.groupid " +
                          " where g.id = @Id " +
                          " order by fullname;";

            var result = conn.Query<GWithSDto>(command, new
            { 
                Id = id 
            });

            return result;
        }
    }

}
