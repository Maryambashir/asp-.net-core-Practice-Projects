using Microsoft.AspNetCore.Http;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Common
{
    public class Utils : IUtils
    {
        public Students StudentMapper(IFormCollection formData)
        {
            try
            {
                Students student = new Students();
                student.Firstname = formData["Firstname"];
                student.Lastname = formData["Lastname"];
                student.Email = formData["Email"];
                if (formData.Files.Count != 0)
                    student.Image = ImageConverter(formData.Files[0]);
                else
                    student.Image = null;
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ImageConverter(IFormFile Image)
        {
            string base64 = "";
            if (Image.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    Image.CopyTo(stream);
                    var fileBytes = stream.ToArray();
                    string encoded = Convert.ToBase64String(fileBytes);
                    base64 = "data:" + Image.ContentType + ";base64," + encoded;
                }
            }

            return base64;

        }
    }
}
