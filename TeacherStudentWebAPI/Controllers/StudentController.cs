using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TeacherStudentDTO.DTOModels;
using TeacherStudentServices.Interfaces;

namespace TeacherStudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService service, ILogger<StudentController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            _logger.LogInformation("GetAllStudents API called");

            var students = await _service.GetStudents();

            _logger.LogInformation("Students fetched successfully");


            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudent([FromBody] StudentDTO student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Creating a new Student");

                    if (student == null)
                    {
                        return BadRequest();
                    }

                    _logger.LogInformation(
                       "Student created successfully with Id: {Student}",
                       student.Id);


                    await _service.InsertStudent(student);
                    return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
                }
                else
                {
                    return BadRequest("Student Not Inserted Successfully");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating Student");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _service.GetStudentById(id);

            _logger.LogInformation("Getting Student with Id: {StudentId}", id);

            if (student == null)
            {
                _logger.LogWarning("Product with Id {StudentId} was not found", id);

                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Updating a new Student");
                    if (student == null)
                    {
                        return BadRequest();
                    }
                    _logger.LogInformation("Updated a New Student");

                    await _service.UpdateStudent(id, student);

                    return Ok("Student Updated Successfully");
                }
                else
                {
                    return BadRequest("Student Not Updated Successfully");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while Updating Student");

                return StatusCode(500, "Internal server error");
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            _logger.LogInformation("Deleting a Student with Id: {StudentId}", id);

            await _service.DeleteStudentById(id);

            _logger.LogInformation("Student with Id: {StudentId} deleted successfully", id);

            return Ok("Student Deleted Successfully");
        }
    }
}
