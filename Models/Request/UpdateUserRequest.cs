namespace UserManagement.Models.Request {
    public class UpdateUserRequest {
        public int id { get; set; }
        public string email { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
    }
}