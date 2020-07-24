using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentPortal.Context;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StudentPortal.Services
{
    public class StudentService : IStudentService
    {
        
        public PortalDbContext _context { get; }
        public StudentService(PortalDbContext Context)
        {
            _context = Context;
        }

        public IEnumerable<Students> GetStudents()
        {
            try
            {
                var students = _context.Students.ToList();
                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Students AddStudent(Students student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Students UpdateStudent(Students student)
        {
            try
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DeleteStudent(int id)
        {
            try
            {
                if (!_context.Students.Any(i => i.Id == id))
                {
                    return false;
                }
                else
                {
                    var deleted = _context.Students.Remove(new Students() { Id = id });
                    if (deleted != null)
                    {
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

    }
}
