using TeacherStudentDAL.Models.Entities;

namespace TeacherStudentRepository.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task InsertTeacher(Teacher teacher);
        Task UpdateTeacher(int id , Teacher teacher);

        Task DeleteTeacherById(int id);
    }
}
