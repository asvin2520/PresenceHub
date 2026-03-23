using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presencehub.Application.Dto;
using Presencehub.Application.ServiceInterface;

namespace Presencehub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServicesInterface roleServicesInterface;
        private readonly ILogger<RoleController> logger;

        public RoleController(IRoleServicesInterface roleServicesInterface, ILogger<RoleController> logger)
        {
            this.roleServicesInterface = roleServicesInterface;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                logger.LogInformation("Fetching all roles");

                var role = await roleServicesInterface.GetAllRoles();

                if (role == null || role.Count == 0)
                {
                    logger.LogWarning("No roles found in database");
                    return NotFound("No Roles Found");
                }

                logger.LogInformation("Roles fetched successfully");
                return Ok(role);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching roles");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDto roleDto)
        {
            try
            {
                logger.LogInformation("Adding new role");

                var res = await roleServicesInterface.AddRole(roleDto);

                if (res > 0)
                {
                    logger.LogInformation("Role added successfully");
                    return Ok("Role Added Successfully");
                }

                logger.LogWarning("Failed to add role");
                return BadRequest("Failed to add role");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding role");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            try
            {
                logger.LogInformation("Deleting role with Id: {RoleId}", roleId);

                var res = await roleServicesInterface.DeleteRole(roleId);

                if (res > 0)
                {
                    logger.LogInformation("Role deleted successfully");
                    return Ok("Deleted Successfully");
                }

                logger.LogWarning("Role deletion failed");
                return BadRequest("Failed to delete role");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting role");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto)
        {
            try
            {
                logger.LogInformation("Updating role");

                var res = await roleServicesInterface.UpdateRole(roleDto);

                if (res > 0)
                {
                    logger.LogInformation("Role updated successfully");
                    return Ok("Role Updated Successfully");
                }

                logger.LogWarning("Failed to update role");
                return BadRequest("Failed to update role");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating role");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{RoleId}")]
        public async Task<IActionResult> GetRoleById(int RoleId)
        {
            try
            {
                logger.LogInformation("Fetching role by Id: {RoleId}", RoleId);

                var res = await roleServicesInterface.GetRoleById(RoleId);

                if (res == null)
                {
                    logger.LogWarning("Role not found with Id: {RoleId}", RoleId);
                    return NotFound("Role not found");
                }

                logger.LogInformation("Role fetched successfully");
                return Ok(res);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching role by Id");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}