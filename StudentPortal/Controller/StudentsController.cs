using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Common;
using StudentPortal.Services;

namespace StudentPortal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public IStudentService StudentService { get; }
        public IUtils utils { get; }
        public StudentsController(IStudentService studentService, IUtils utils)
        {
            this.StudentService = studentService;
            this.utils = utils;
        }

        [Route("GetAllStudents")]
        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var Students = StudentService.GetStudents();
                ResponseDTO response = new ResponseDTO();
                if (Students != null)
                {
                    response.StatusCode = "Success";
                    response.Message = "Successfully fetched the list.";
                    response.Data = Students;
                    return Ok(response);
                }
                else
                {
                    response.StatusCode = "Warning";
                    response.Message = "Invalid request.";
                    response.Data = null;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                ResponseDTO Failure = new ResponseDTO();
                Failure.StatusCode = "Failed";
                Failure.Message = ex.Message;
                Failure.Data = null;
                return BadRequest(Failure);

            }
        }

        [Route("CreateStudent")]
        [HttpPost]
        public IActionResult CreateStudent([FromForm] IFormCollection data)
        {
            try
            {
                Students student = utils.StudentMapper(data);
                var AddedStudent = StudentService.AddStudent(student);
                ResponseDTO response = new ResponseDTO();
                if (AddedStudent != null)
                {
                    response.StatusCode = "Success";
                    response.Message = "Successfully Created";
                    response.Data = AddedStudent;
                    return Ok(response);
                }
                else
                {
                    response.StatusCode = "Warning";
                    response.Message = "Invalid request.";
                    response.Data = null;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                ResponseDTO Failure = new ResponseDTO();
                Failure.StatusCode = "Failed";
                Failure.Message = ex.Message;
                Failure.Data = null;
                return BadRequest(Failure);

            }
        }

        [Route("CreateStudentNew")]
        [HttpPost]
        public IActionResult CreateStudentNew([FromBody] Students student)
        {
            try
            {
                var AddedStudent = StudentService.AddStudent(student);
                ResponseDTO response = new ResponseDTO();
                if (AddedStudent != null)
                {
                    response.StatusCode = "Success";
                    response.Message = "Successfully Created";
                    response.Data = AddedStudent;
                    return Ok(response);
                }
                else
                {
                    response.StatusCode = "Warning";
                    response.Message = "Invalid request.";
                    response.Data = null;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                ResponseDTO Failure = new ResponseDTO();
                Failure.StatusCode = "Failed";
                Failure.Message = ex.Message;
                Failure.Data = null;
                return BadRequest(Failure);

            }
        }

        [Route("UpdateStudent")]
        [HttpPost]
        public IActionResult UpdateStudent([FromForm] Students student)
        {
            try
            {
                var UpdatedStudent = StudentService.UpdateStudent(student);
                ResponseDTO response = new ResponseDTO();
                if (UpdatedStudent != null)
                {
                    return Redirect("/");
                    //response.StatusCode = "Success";
                    //response.Message = "Successfully Updated";
                    //response.Data = UpdatedStudent;
                    //return Ok(response);
                }
                else
                {
                    response.StatusCode = "Warning";
                    response.Message = "Invalid request.";
                    response.Data = null;
                    return BadRequest(response);
                }
                
            }
            catch (Exception ex)
            {
                ResponseDTO Failure = new ResponseDTO();
                Failure.StatusCode = "Failed";
                Failure.Message = ex.Message;
                Failure.Data = null;
                return BadRequest(Failure);

            }
        }

        [Route("DeleteStudent")]
        [HttpPost]
        public IActionResult DeleteStudent([FromBody] StudentsDTO student)
        {
            try
            {
                Boolean Status = StudentService.DeleteStudent(student.Id);
                ResponseDTO response = new ResponseDTO();
                if (Status == true)
                {
                    response.StatusCode = "Success";
                    response.Message = "Successfully Deleted";
                    response.Data = Status;
                    return Ok(response);
                }
                else
                {
                    response.StatusCode = "Warning";
                    response.Message = "Can't Delete";
                    response.Data = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                ResponseDTO Failure = new ResponseDTO();
                Failure.StatusCode = "Failed";
                Failure.Message = ex.Message;
                Failure.Data = false;
                return BadRequest(Failure);

            }
        }


    }
}