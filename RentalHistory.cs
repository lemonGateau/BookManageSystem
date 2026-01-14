using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookManageSystem
{
    [Table("rental_history")]
    public class RentalHistory
    {
        [Key]
        [Column("history_id")]
        public int HistoryId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("rental_date")]
        public DateTime? RentalDate { get; set; }

        [Column("return_date")]
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("ItemId")]
        public virtual BookItem BookItem { get; set; } = null!;

        [ForeignKey("UserId")]
        public virtual Employee Employee { get; set; } = null!;
    }
}
