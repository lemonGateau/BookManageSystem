using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManageSystem
{
    [Table("book_item")]
    public class BookItem
    {
        [Key]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("isbn")]
        public string Isbn { get; set; } = null!;

        [Column("office_id")]
        public int OfficeId { get; set; }

        [Column("rack_id")]
        public string RackId { get; set; } = null!;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [ForeignKey("Isbn")]
        public virtual Book Book { get; set; } = null!;

        [ForeignKey("OfficeId")]
        public virtual Office Office { get; set; } = null!;

        [ForeignKey("RackId")]
        public virtual Rack Rack { get; set; } = null!;
    }
}
