using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherStudentDAL.Models.Entities;
using TeacherStudentRepository.Interfaces;

namespace TeacherStudentRepository.Implemaintations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TeacherStudentDbContext _context;

        public StudentRepository(TeacherStudentDbContext context)
        {
            _context = context;
        }

        public async Task DeleteStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if(student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);   
            
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task InsertStudent(Student student)
        {
            if(student != null)
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
        }

        public async Task UpdateStudent(int id, Student student)
        {
            var existingStudent = await _context.Students.FindAsync(id);

            if(existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.LastName = student.LastName;
                existingStudent.Age = student.Age;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.TeacherId = student.TeacherId;

                _context.Students.Update(existingStudent);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Student with ID {id} not found.");
            }
        }
    }
}
