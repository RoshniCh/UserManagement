namespace UserManagement.Models.Request {
    public class CreateUserRequest {
        public string email { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
    }
}