using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Models
{
    public class UserAddressModel : BaseModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public CityModel City { get; set; }
        public UserModel User { get; set; }
        public StateModel State { get; set; }
        public CountryModel Country { get; set; }
        public bool Current { get; set; }
    }
}
