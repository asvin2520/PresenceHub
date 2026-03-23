using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presencehub.Application.Dto;
using Presencehub.Application.ServiceInterface;

namespace Presencehub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendencesController : ControllerBase
    {
        private readonly IAttendenceServicesInterface attendenceServicesInterface;
        private readonly ILogger<AttendencesController> logger;

        public AttendencesController(
            IAttendenceServicesInterface attendenceServicesInterface,
            ILogger<AttendencesController> logger)
        {
            this.attendenceServicesInterface = attendenceServicesInterface;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            try
            {
                logger.LogInformation("Fetching all attendance records");

                var atten = await attendenceServicesInterface.GetAllUser();

                if (atten == null || atten.Count == 0)
                {
                    logger.LogWarning("No attendance records found");
                    return NotFound("No Attendance Records Found");
                }

                logger.LogInformation("Attendance records fetched successfully");
                return Ok(atten);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching attendance records");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AttendanceDto attendanceDto)
        {
            try
            {
                logger.LogInformation("Adding new attendance record");

                var atten = await attendenceServicesInterface.AddUser(attendanceDto);

                if (atten > 0)
                {
                    logger.LogInformation("Attendance record added successfully");
                    return Ok("Added Successfully");
                }

                logger.LogWarning("Failed to add attendance record");
                return BadRequest("Failed to add");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding attendance");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                logger.LogInformation("Deleting attendance record with Id: {Id}", id);

                var result = await attendenceServicesInterface.DeleteUser(id);

                if (result == null)
                {
                    logger.LogWarning("Attendance record not found for Id: {Id}", id);
                    return NotFound("Attendance record not found");
                }

                logger.LogInformation("Attendance record deleted successfully");
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting attendance");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(AttendanceDto attendanceDto)
        {
            try
            {
                logger.LogInformation("Updating attendance record");

                var atten = await attendenceServicesInterface.UpdateUser(attendanceDto);

                if (atten > 0)
                {
                    logger.LogInformation("Attendance updated successfully");
                    return Ok("Update Successfully");
                }

                logger.LogWarning("Failed to update attendance");
                return BadRequest("Failed to Update");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating attendance");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                logger.LogInformation("Fetching attendance record by Id: {Id}", id);

                var result = await attendenceServicesInterface.GetUserById(id);

                if (result == null)
                {
                    logger.LogWarning("Attendance record not found with Id: {Id}", id);
                    return NotFound("Attendance not found");
                }

                logger.LogInformation("Attendance record fetched successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching attendance by Id");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}