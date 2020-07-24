using Microsoft.AspNetCore.Http;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Common
{
    public interface IUtils
    {
        public Students StudentMapper(IFormCollection formData);
        public string ImageConverter(IFormFile Image);
    }
}
