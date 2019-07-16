using ECommerce_Commons.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce_Application.Models
{
    public class UserRoleModel : BaseModel
    {
        [Required(ErrorMessage = "this field is required")]
        public string Name { get; set; }
        public Enumerators.AccessLevel AccessLevel { get; set; }

        public string AccessLevelTostring => AccessLevel.ToString();
    }
}
