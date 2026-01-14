using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookManageSystem
{
    [Table("office")]
    public class Office
    {
        [Key]
        [Column("office_id")]
        public int OfficeId { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("prefecture")]
        public string Prefecture { get; set; } = null!;

        [Column("city")]
        public string City { get; set; } = null!;

        [Column("address")]
        public string Address { get; set; } = null!;

        public Office()
        {

        }

        public Office(int officeId, string name)
        {
            OfficeId = officeId;
            Name = name;
        }

        public Office(int officeId, string name, string prefecture, string city, string address)
        {
            OfficeId = officeId;
            Name = name;
            Prefecture = prefecture;
            City = city;
            Address = address;
        }
    }
}
