using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManageSystem
{
    [Table("reservation_status")]
    public class ReservationStatus
    {
        [Key]
        [Column("status_id")]
        public int StatusId { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;
    }

    public enum StatusId
    {
        Reserved = 0,
        Completed = 1,
        Cancelled = 2
    }
}
