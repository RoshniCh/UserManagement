using Microsoft.EntityFrameworkCore;
using UserManagement.Models.Database;

namespace UserManagement {
    public class UserManagementDbContext : DbContext { 
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options) {}
        public DbSet<user> user { get; set; } 
    }
}