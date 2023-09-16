using Domain.Models.GroupDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GSApi.Controllers;

[ApiController]
[Route("[controller]")]

public class GroupController : ControllerBase
{
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost("AddGroup")]
    public string AddGroup(AUGroupDto group)
    {
        return _groupService.AddGroup(group);
    }

    [HttpPut("UpdateGroup")]
    public string UpdateGroup(AUGroupDto group)
    {
        return _groupService.UpdateGroup(group);
    }

    [HttpDelete("DeleteGroup")]
    public string DeleteGroup(int id)
    {
        return _groupService.DeleteGroup(id);
    }

    [HttpGet("GetAllGroups")]
    public IEnumerable<GGroupDto> GetAllGroups()
    {
        return _groupService.GetAllGroups();
    }

    [HttpGet("GetGroupById")]
    public GGroupDto GetGroupById(int id)
    {
        return _groupService.GetGroupById(id);
    }

    [HttpGet("GetAllGroupsWithStudents")]
    public IEnumerable<GWithSDto> GetAllGroupsWithStudents()
    {
        return _groupService.GetAllGroupsWithStudents();
    }

    [HttpGet("GetGroupByIdWithStudents")]
    public IEnumerable<GWithSDto> GetGroupByIdWithStudents(int id)
    {
        return _groupService.GetGroupByIdWithStudents(id);
    }
}
