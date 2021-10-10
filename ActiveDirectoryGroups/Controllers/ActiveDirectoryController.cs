using ActiveDirectoryGroups.Services;

namespace ActiveDirectoryGroups.Controllers
{
    [Route("api/[controller]")]
    public class ActiveDirectoryController : ControllerBase
    {
        private readonly ActiveDirectoryGroupsService activeDirectoryGroupsService;

        public ActiveDirectoryController(ActiveDirectoryGroupsService activeDirectoryGroupsService)
        {
            this.activeDirectoryGroupsService = activeDirectoryGroupsService;
        }

        [HttpGet("{username}/groupNames")]
        public IActionResult GetGroupNames(string username)
        {
            IEnumerable<string> groupNames = activeDirectoryGroupsService.GetGroupNames(username);
            return Ok(groupNames);
        }
    }
}
