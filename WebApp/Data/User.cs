using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<UserRole> Roles { get; set; }
    }

    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }

    }
}
