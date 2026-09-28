using Microsoft.EntityFrameworkCore;
using TeacherStudentDAL.Models.Entities;
using TeacherStudentRepository.Interfaces;

namespace TeacherStudentRepository.Implemaintations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeacherStudentDbContext _context;

        public TeacherRepository(TeacherStudentDbContext context)
        {
            _context = context;
        }

        public async Task DeleteTeacherById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task InsertTeacher(Teacher teacher)
        {
            if(teacher != null)
            {
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync();
            }
            else
            {
                 throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
            }
        }

        public async Task UpdateTeacher(int id, Teacher teacher)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher != null)
            {
                existingTeacher.TeacherId = teacher.TeacherId;
                existingTeacher.TeacherName = teacher.TeacherName;
                existingTeacher.TeacherEmail = teacher.TeacherEmail;
                existingTeacher.TeacherSubject = teacher.TeacherSubject;
                // Update other properties as needed

                await _context.SaveChangesAsync();
            }   
        }
    }
}
