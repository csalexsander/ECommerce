using System.ComponentModel.DataAnnotations;

namespace ECommerce_Application.Models
{
    public class UserModel : BaseModel
    {
        [Required(ErrorMessage = "this field is required")]
        public string Name { get; set; }
        public UserRoleModel Role { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public long RoleId { get; set; }
        public bool UserBlock { get; set; }
        public bool PasswordReset { get; set; }
        public bool Remember { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Email { get; set; }

    }
}
