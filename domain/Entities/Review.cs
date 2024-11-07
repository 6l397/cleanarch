using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string Content { get; set; } = null!;

        public int? Rating { get; set; }

        public DateTime? ReviewDate { get; set; }

        public int? SellerId { get; set; }

        public int? ServiceId { get; set; }
    }
}
