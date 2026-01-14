using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManageSystem
{
    [Table("reservation")]
    public class Reservation
    {
        [Key]
        [Column("reservation_id")]
        public int ReservationId { get; set; }

        [Column("isbn")]
        public string Isbn { get; set; } = null!;

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("status_id")]
        public int StatusId { get; set; }

        [ForeignKey("Isbn")]
        public virtual Book Book { get; set; } = null!;

        [ForeignKey("UserId")]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey("StatusId")]
        public virtual ReservationStatus ReservationStatus { get; set; } = null!;
    }
}
