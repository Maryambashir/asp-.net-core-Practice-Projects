using Newtonsoft.Json;

namespace StudentPortal.Models
{
    public class ResponseDTO
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public object Data { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
