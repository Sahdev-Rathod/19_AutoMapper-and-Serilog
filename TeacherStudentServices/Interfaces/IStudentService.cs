using TeacherStudentDTO.DTOModels;

namespace TeacherStudentServices.Interfaces
{
    public interface IStudentService 
    {
        Task<IEnumerable<StudentDTO>> GetStudents();
        Task<StudentDTO> GetStudentById(int id);
        Task InsertStudent(StudentDTO student);
        Task UpdateStudent(int id, StudentDTO student);
        Task DeleteStudentById(int id);
    }
}
