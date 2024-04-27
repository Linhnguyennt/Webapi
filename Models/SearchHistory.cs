using System;
using System.Collections.Generic;

namespace _2704.Models
{
    public partial class SearchHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? SearchTime { get; set; }

        public virtual Location? Location { get; set; }
        public virtual User? User { get; set; }
    }
}
