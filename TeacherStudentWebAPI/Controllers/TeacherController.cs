using Microsoft.AspNetCore.Mvc;
using TeacherStudentDTO.DTOModels;
using TeacherStudentServices.Interfaces;

namespace TeacherStudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        private readonly ILogger<TeacherController> _logger;
        public TeacherController(ITeacherService service , ILogger<TeacherController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            _logger.LogInformation("GetAllTeachers API called");

            var teachers = await _service.GetTeachers();

            _logger.LogInformation("Teachers fetched successfully");

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _service.GetTeacherById(id);

            _logger.LogInformation("Getting Teacher with Id: {TeacherId}", id);

            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTeacher([FromBody] TeacherDTO teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("InsertTeacher API called");

                    if (teacher == null)
                    {
                        return BadRequest();
                    }

                    _logger.LogInformation("Teacher Created Successfully");

                    await _service.InsertTeacher(teacher);
                    return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
                }
                else
                {
                    return BadRequest("Teacher Not Inserted Successfully");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex , "error while creating a teachers");

                return StatusCode(500, "Internal Server Error");
            }
          
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDTO teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Updating a New Teacher");

                    if (teacher == null || id != teacher.TeacherId)
                    {
                        return BadRequest();
                    }
                    _logger.LogInformation("Teacher Updated Successfully");

                    await _service.UpdateTeacher(id, teacher);

                    return Ok("Employee Updated Successfully");
                }
                else
                {
                    return BadRequest("Teacher Not Updated Successfully");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Teacher");

                return StatusCode(500, "Internal Server Error");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Deleting a Teacher with Id: {TeacherId}", id);

                await _service.DeleteTeacherById(id);

                _logger.LogInformation("Teacher with Id: {TeacherId} deleted successfully", id);

                return Ok("Teacher Deleted Successfully");
            }
            else
            {
                _logger.LogError("Error While Deleting a Teacher");

                return BadRequest("Teacher Not Deleted Successfully");
                
            }
        }
    }
}
