using AutoMapper;
using TeacherStudentDAL.Models.Entities;
using TeacherStudentDTO.DTOModels;
using TeacherStudentRepository.Interfaces;
using TeacherStudentServices.Interfaces;

namespace TeacherStudentServices.Implemaintations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task DeleteStudentById(int id)
        {
            await _repo.DeleteStudentById(id);
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            var student = await _repo.GetStudentById(id);

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
           var students = await _repo.GetStudents();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task InsertStudent(StudentDTO student)
        {
            if(student != null)
            {
                var studentEntity = _mapper.Map<Student>(student);

                await _repo.InsertStudent(studentEntity);
            }          
        }

        public async Task UpdateStudent(int id, StudentDTO student)
        {
            if (student != null && id > 0)
            {
                var studentEntity = _mapper.Map<Student>(student);

                await _repo.UpdateStudent(id, studentEntity);
            }
        }
    }
}
