using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManageSystem
{
    [Table("author_books")]
    public class AuthorBook
    {
        [Column("isbn")]
        public string Isbn { get; set; } = null!;

        [Column("author_id")]
        public int AuthorId { get; set; }

        [ForeignKey("Isbn")]
        public virtual Book Book { get; set; } = null!;

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; } = null!;
    }
}
