using System;
using System.Collections.Generic;

namespace _2704.Models
{
    public partial class User
    {
        public User()
        {
            SearchHistories = new HashSet<SearchHistory>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<SearchHistory> SearchHistories { get; set; }
    }
}
