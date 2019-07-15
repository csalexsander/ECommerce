using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    public class ReturnDefault
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public object Data { get; set; }
        public string Url { get; set; }
        public bool Redirect { get; set; }

        public ReturnDefault(bool success, string message, string title, object data, string url, bool redirect)
        {
            Success = success;
            Message = message;
            Title = title;
            Data = data;
            Url = url;
            Redirect = redirect;
        }

        public ReturnDefault(bool success, string message, string title, object data) : this(success, message, title, data, string.Empty, false)
        {
        }

        public ReturnDefault(bool success, string message, string title) : this(success, message, title, null, string.Empty, false)
        {
        }

        public ReturnDefault(bool success, string message) : this(success, message, string.Empty, null, string.Empty, false)
        {
        }

        public ReturnDefault(bool success, string title, object data) : this(success, string.Empty, title, data, string.Empty, false)
        {
        }

        public ReturnDefault(bool success, string url, bool redirect) :this(success, string.Empty, string.Empty, null, url, redirect)
        {            
        }
    }
}
