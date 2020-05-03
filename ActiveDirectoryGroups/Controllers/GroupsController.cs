using ActiveDirectoryGroups.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ActiveDirectoryGroups.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly ActiveDirectoryGroupsService activeDirectoryGroupsService;

        public GroupsController(ActiveDirectoryGroupsService activeDirectoryGroupsService)
        {
            this.activeDirectoryGroupsService = activeDirectoryGroupsService;
        }

        [HttpGet("{username}/activeDirectory")]
        public IActionResult GetActiveDirectoryGroups(string username)
        {
            IEnumerable<string> activeDirectoryGroups = activeDirectoryGroupsService.GetGroups(username);
            return Ok(activeDirectoryGroups);
        }
    }
}
