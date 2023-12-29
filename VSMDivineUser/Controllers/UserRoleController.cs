using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VSMDivineUser.Models;
using VSMDivineUser.Service.Services;

namespace VSMDivineUser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet("AllUserRoles")]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetAllUserRoles()
        {
            var users = await _userRoleService.GetAllUserRoles();
            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetAllUserRoles(int pageIndex = 1, int pageSize = 10)
        {
            var users = await _userRoleService.GetAllUserRoles(pageIndex, pageSize);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRoleById(int id)
        {
            var user = await _userRoleService.GetUserRoleById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserRole(UserRole userRole)
        {
            userRole.CreatedDate = DateTime.UtcNow;
            userRole.IsActive = true;
            await _userRoleService.AddUserRole(userRole);
            return CreatedAtAction(nameof(GetUserRoleById), new { id = userRole.Id }, userRole);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserRole(int id, UserRole userRole)
        {
            if (id != userRole.Id)
            {
                return BadRequest();
            }

            await _userRoleService.UpdateUserRole(userRole);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserRole(int id)
        {
            var userRole = await _userRoleService.GetUserRoleById(id);
            if (userRole == null)
            {
                return NotFound();
            }

            await _userRoleService.DeleteUserRole(userRole);
            return NoContent();

        }
    }


}
