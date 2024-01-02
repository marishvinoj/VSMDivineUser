using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VSMDivineUser.Models;
using VSMDivineUser.Models.Dtos;
using VSMDivineUser.Service.Services;

namespace VSMDivineUser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleMappingController : ControllerBase
    {
        private readonly IUserRoleMappingService _userRoleMappingService;

        public UserRoleMappingController(IUserRoleMappingService userRoleMappingService)
        {
            _userRoleMappingService = userRoleMappingService;
        }

        [HttpGet("AllUserRoleMappings")]
        public async Task<ActionResult<IEnumerable<UserRoleMapping>>> GetAllUserRoleMappings()
        {
            var users = await _userRoleMappingService.GetAllUserRoleMappings();
            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleMapListDto>>> GetAllUserRoleMappings(int pageIndex = 1, int pageSize = 10)
        {
            var users = await _userRoleMappingService.GetAllUserRoleMappings(pageIndex, pageSize);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleMapping>> GetUserRoleMappingById(int id)
        {
            var user = await _userRoleMappingService.GetUserRoleMappingById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserRoleMapping(UserRoleMappingDto usrRoleMap)
        {
            var res = await _userRoleMappingService.GetUserRoleMappingByUserId(usrRoleMap.UserID);

            await _userRoleMappingService.Post(usrRoleMap);
            //return CreatedAtAction(nameof(GetUserRoleMappingById), new { id = userRoleMapping.Id }, userRoleMapping);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserRoleMapping(int id, UserRoleMapping userRoleMapping)
        {
            if (id != userRoleMapping.Id)
            {
                return BadRequest();
            }

            await _userRoleMappingService.UpdateUserRoleMapping(userRoleMapping);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserRoleMapping(int id)
        {
            var userRoleMapping = await _userRoleMappingService.GetUserRoleMappingById(id);
            if (userRoleMapping == null)
            {
                return NotFound();
            }

            await _userRoleMappingService.DeleteUserRoleMapping(userRoleMapping);
            return NoContent();

        }
    }


}
