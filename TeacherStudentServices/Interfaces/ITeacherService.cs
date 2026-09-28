using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherStudentDAL.Models.Entities;
using TeacherStudentDTO.DTOModels;

namespace TeacherStudentServices.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDTO>> GetTeachers();
        Task<TeacherDTO> GetTeacherById(int id);
        Task InsertTeacher(TeacherDTO teacher);
        Task UpdateTeacher(int id, TeacherDTO teacher);
        Task DeleteTeacherById(int id);
    }
}
