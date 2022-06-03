using Newtonsoft.Json;

namespace StudentManagement.Api.Middleware
{
    public class ErrorResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public object error { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
