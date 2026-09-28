using AutoMapper;
using TeacherStudentDAL.Models.Entities;
using TeacherStudentDTO.DTOModels;

namespace TeacherStudentServices.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
