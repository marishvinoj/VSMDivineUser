using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VSMDivineUser.Models;
using VSMDivineUser.Service.Services;

namespace VSMDivineUser.Controllers
{
    //[Route("[controller]")]
    //[EnableCors("OpenCORSPolicy")]
    //public class UserController : Controller
    //{
    //    #region ===[ Private Members ]=============================================================

    //    private readonly IUnitOfWork _unitOfWork;

    //    #endregion

    //    #region ===[ Constructor ]=================================================================

    //    /// <summary>
    //    /// Initialize UserController by injecting an object type of IUnitOfWork
    //    /// </summary>
    //    public UserController(IUnitOfWork unitOfWork)
    //    {
    //        this._unitOfWork = unitOfWork;
    //    }

    //    #endregion

    //    #region ===[ Public Methods ]==============================================================

    //    [HttpGet("GetUserList")]
    //    public async Task<ApiResponse<List<User>>> GetAll(int pageSize = 10, int pageNumber = 1)
    //    {
    //        var apiResponse = new ApiResponse<List<User>>();

    //        try
    //        {
    //            Log.Information($"Start Time {DateTime.Now}");
    //            var data = await _unitOfWork.Users.GetAllAsync(pageSize, pageNumber);
    //            Log.Information($"End Time {DateTime.Now}");
    //            apiResponse.Success = true;
    //            apiResponse.Result = data.ToList();
    //        }
    //        catch (SqlException ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "SQL Exception:");
    //        }
    //        catch (Exception ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "Exception:");
    //        }

    //        return apiResponse;
    //    }

    //    [HttpGet("GetUserById")]
    //    public async Task<ApiResponse<User>> GetById(int Id)
    //    {

    //        var apiResponse = new ApiResponse<User>();

    //        try
    //        {
    //            var data = await _unitOfWork.Users.GetByIdAsync(Id);
    //            apiResponse.Success = true;
    //            apiResponse.Result = data;
    //        }
    //        catch (SqlException ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "SQL Exception:");
    //        }
    //        catch (Exception ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "Exception:");
    //        }

    //        return apiResponse;
    //    }

    //    [HttpPost("AddUser")]
    //    public async Task<ApiResponse<string>> Add([FromBody] User User)
    //    {
    //        var apiResponse = new ApiResponse<string>();

    //        try
    //        {
    //            var data = await _unitOfWork.Users.AddAsync(User);
    //            apiResponse.Success = true;
    //            apiResponse.Result = data;
    //        }
    //        catch (SqlException ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "SQL Exception:");
    //        }
    //        catch (Exception ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "Exception:");
    //        }

    //        return apiResponse;
    //    }

    //    [HttpPut("UpdateUser")]
    //    public async Task<ApiResponse<string>> Update([FromBody] User User)
    //    {
    //        var apiResponse = new ApiResponse<string>();

    //        try
    //        {
    //            var data = await _unitOfWork.Users.UpdateAsync(User);
    //            apiResponse.Success = true;
    //            apiResponse.Result = data;
    //        }
    //        catch (SqlException ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "SQL Exception:");
    //        }
    //        catch (Exception ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "Exception:");
    //        }

    //        return apiResponse;
    //    }

    //    [HttpDelete]
    //    public async Task<ApiResponse<string>> Delete(int id)
    //    {
    //        var apiResponse = new ApiResponse<string>();

    //        try
    //        {
    //            var data = await _unitOfWork.Users.DeleteAsync(id);
    //            apiResponse.Success = true;
    //            apiResponse.Result = data;
    //        }
    //        catch (SqlException ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "SQL Exception:");
    //        }
    //        catch (Exception ex)
    //        {
    //            apiResponse.Success = false;
    //            apiResponse.Message = ex.Message;
    //            Log.Error(ex, "Exception:");
    //        }

    //        return apiResponse;
    //    }

    //    #endregion
    //}

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(int pageIndex = 1, int pageSize = 10)
        {
            var users = await _userService.GetAllUsers(pageIndex, pageSize);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(user);
            return NoContent();

        }
    }
}
