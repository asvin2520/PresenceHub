using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presencehub.Application.Dto;
using Presencehub.Application.ServiceClass;
using Presencehub.Application.ServiceInterface;

namespace Presencehub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServicesInterface userServicesInterface;
        private readonly TokenServices tokenServices;
        private readonly ILogger<UserController> logger;

        public UserController(
            IUserServicesInterface userServicesInterface,
            TokenServices tokenServices,
            ILogger<UserController> logger)
        {
            this.userServicesInterface = userServicesInterface;
            this.tokenServices = tokenServices;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(PostDto userDto)
        {
            try
            {
                logger.LogInformation("Adding new user");

                if (userDto == null)
                {
                    logger.LogWarning("User data is null");
                    return BadRequest("User data is required");
                }

                var res = await userServicesInterface.AddUser(userDto);

                logger.LogInformation("User added successfully");
                return Ok(res);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding user");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                logger.LogInformation("Fetching all users");

                var res = await userServicesInterface.GetAllUser();

                logger.LogInformation("Users fetched successfully");
                return Ok(res);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching users");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                logger.LogInformation("Fetching user with Id: {UserId}", id);

                var res = await userServicesInterface.GetUserById(id);

                if (res == null)
                {
                    logger.LogWarning("User not found with Id: {UserId}", id);
                    return NotFound("User not found");
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching user by id");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                logger.LogInformation("Deleting user with Id: {UserId}", id);

                var res = await userServicesInterface.DeleteUser(id);

                if (res == null)
                {
                    logger.LogWarning("User not found for deletion: {UserId}", id);
                    return NotFound("User not found");
                }

                logger.LogInformation("User deleted successfully");
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting user");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(PostDto postDto)
        {
            try
            {
                logger.LogInformation("Updating user");

                var res = await userServicesInterface.UpdateUser(postDto);

                if (res > 0)
                {
                    logger.LogInformation("User updated successfully");
                    return Ok("User Updated Successfully");
                }

                logger.LogWarning("Failed to update user");
                return BadRequest("Failed to Update User");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating user");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                logger.LogInformation("User login attempt: {UserName}", login.UserName);

                var user = await userServicesInterface.LoginUser(login);

                if (user == null)
                {
                    logger.LogWarning("Invalid login attempt for user: {UserName}", login.UserName);
                    return Unauthorized("Invalid Username or Password");
                }

                var token = tokenServices.GenerateToken(user.UserName);

                logger.LogInformation("User logged in successfully: {UserName}", user.UserName);

                return Ok(new
                {
                    Token = token
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred during login");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}