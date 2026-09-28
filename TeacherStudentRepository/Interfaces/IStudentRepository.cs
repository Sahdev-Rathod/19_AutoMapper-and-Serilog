using TeacherStudentDAL.Models.Entities;

namespace TeacherStudentRepository.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task InsertStudent(Student student);
        Task UpdateStudent(int id, Student student);
        Task DeleteStudentById(int id);
    }
}
