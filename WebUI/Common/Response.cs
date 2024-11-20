using System.Collections.Generic;

namespace WebUI.Common
{
    public class Response<T>
    {
        public Response()
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = new List<string>();
        }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = new List<string>();
            Data = data;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
       
    }
}