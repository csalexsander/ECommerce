using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Models
{
    public class CountryModel : BaseModel
    {
        public string Name { get; set; }
        public virtual List<StateModel> States { get; set; }
        public virtual List<CityModel> Cities { get; set; }
    }
}
