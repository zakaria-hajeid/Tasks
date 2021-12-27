using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Application.Dtos
{
    public class CJsonObject<T>
    {
        public CJsonObject()
        {
        }

        public CJsonObject(bool status = true, string message = "")
        {
            Status = status;
            Message = message;
        }

        public CJsonObject(T data, bool status = true, string message = "")
        {
            Data = data;
            Status = status;
            Message = message;
        }

        public T Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
