using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherStudentDTO.DTOModels
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public string PhoneNumber { get; set; }

        public int? TeacherId { get; set; }
    }
}
