using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BookManageSystem
{
    [Table("book")]
    public class Book
    {
        [Key]
        [Column("isbn")]
        public string Isbn { get; set; } = null!;

        [Column("title")]
        public string Title { get; set; } = null!;
        
        [Column("publisher_id")]
        public int PublisherId { get; set; }
        
        [Column("category_id")]
        public int CategoryId { get; set; }
        
        [Column("price")]
        public int Price {  get; set; }
        
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; } = null!;

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
    }
}
