using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Models
{
    public class StateModel : BaseModel
    {
        public string Name { get; set; }
        public CountryModel Country { get; set; }
    }
}
