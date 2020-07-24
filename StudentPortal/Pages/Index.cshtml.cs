using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StudentPortal.Models;
using StudentPortal.Services;

namespace StudentPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IStudentService service;

        public IEnumerable<Students> StudentsList { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            IStudentService studentService)
        {
            _logger = logger;
            service = studentService;
        }

        public void OnGet()
        {
           // StudentsList = service.GetStudents();
        }
    }
}