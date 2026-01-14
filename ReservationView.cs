using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookManageSystem
{
    public class ReservationView
    {
        // 識別用
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        // 表示用
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string StatusName { get; set; } = null!;
    }
}
