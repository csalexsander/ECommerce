using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreationDate { get; set; }
    }
}
