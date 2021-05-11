using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Request {
    public class CreateUserRequest {
        [Required]
        public string email { get; set; }
        [Required]
        public string givenName { get; set; }
        [Required]
        public string familyName { get; set; }
    }
}