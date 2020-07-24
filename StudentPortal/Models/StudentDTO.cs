using Microsoft.AspNetCore.Http;

namespace StudentPortal.Models
{
    public class StudentsDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public IFormFile Image { get; set; }
    }
}
