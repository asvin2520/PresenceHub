using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presencehub.Application.Dto;
using Presencehub.Application.ServiceInterface;
using Presencehub.Domain.Entity;

namespace Presencehub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServicesInterface roleServicesInterface;

        public RoleController(IRoleServicesInterface roleServicesInterface)
        {
            this.roleServicesInterface = roleServicesInterface;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            IList<RoleDto> role;
            try
            {
                role = await roleServicesInterface.GetAllRoles();
                if (role == null || role.Count == 0) 
                {
                    return NotFound("No Roles Founds.*");

                }

            }
            catch (Exception ex)
            {

                return BadRequest("No roles founds");
            }
            return Ok (role);
        }

        [HttpPost]
        public async Task<IActionResult>AddRole(RoleDto roleDto) 
        {
            var res=await roleServicesInterface.AddRole(roleDto);
            if (res > 0)
            {
                return Ok("Role Added Successfully");
            }

            return BadRequest("Failed to add role");
            
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteRole(int roleId) 
        {
            var res=await roleServicesInterface.DeleteRole(roleId);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto)
        {

            var res= await roleServicesInterface.UpdateRole(roleDto);
            if (res > 0)
            {
                return Ok("Role Update Successfully");
            }

            return BadRequest("Failed to Update role");

           
        }
        [HttpGet("{RoleId}")]
        public async Task<IActionResult>GetRoleById(int RoleId) 
        {
            var res=await roleServicesInterface.GetRoleById(RoleId);
            return Ok(res);
        }
    }
}
