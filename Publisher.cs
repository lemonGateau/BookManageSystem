using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text;

namespace BookManageSystem
{
    [Table("publisher")]
    public class Publisher
    {
        [Key]
        [Column("publisher_id")]
        public int PublisherId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public Publisher()
        {

        }

        public Publisher(string name)
        {
            Name = name; 
        }

        public Publisher(int publishId, string name)
        {
            PublisherId = publishId;
            Name = name;
        }
    }
}
