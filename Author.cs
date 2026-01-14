using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManageSystem
{
    [Table("author")]
    public class Author
    {
        [Key]
        [Column("author_id")]
        public int AuthorId { get; set; }

        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [Column("birthday")]
        public DateTime? Birthday { get; set; }
    }
}
