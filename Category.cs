using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManageSystem
{
    [Table("category")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public Category()
        {

        }

        public Category(string name)
        {
            Name = name; 
        }

        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
