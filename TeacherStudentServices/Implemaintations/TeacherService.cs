using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherStudentDAL.Models.Entities;
using TeacherStudentDTO.DTOModels;
using TeacherStudentRepository.Interfaces;
using TeacherStudentServices.Interfaces;

namespace TeacherStudentServices.Implemaintations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repo;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task DeleteTeacherById(int id)
        {
            await _repo.DeleteTeacherById(id);
        }

        public async Task<TeacherDTO> GetTeacherById(int id)
        {
           var teacher = await _repo.GetTeacherById(id);

            return _mapper.Map<TeacherDTO>(teacher);    
        }

        public async Task<IEnumerable<TeacherDTO>> GetTeachers()
        {
            var teachers = await _repo.GetTeachers();

            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers);
        }

        public async Task InsertTeacher(TeacherDTO teacher)
        {
            var teacherEntity = _mapper.Map<Teacher>(teacher);

            await _repo.InsertTeacher(teacherEntity);
        }

        public async Task UpdateTeacher(int id, TeacherDTO teacher)
        {
            var teacherEntity = _mapper.Map<Teacher>(teacher);

            await _repo.UpdateTeacher(id, teacherEntity);
        }
    }
}
