using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Services
{
    public interface IStudentService
    {
        public IEnumerable<Students> GetStudents();
        public Students AddStudent(Students student);
        public Students UpdateStudent(Students student);
        public Boolean DeleteStudent(int id);
    }
}
