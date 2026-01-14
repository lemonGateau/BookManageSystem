using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookManageSystem
{
    [Table("rack")]
    public class Rack
    {
        [Column("office_id")]
        public int OfficeId { get; set; }

        [Column("rack_id")]
        public string RackId { get; set; }

        [Column("max_capacity")]
        public int MaxCapacity { get; set; }

        public Rack()
        {

        }

        public Rack(int officeId, string rackId, int maxCapacity)
        {
            OfficeId = officeId;
            RackId = rackId;
            MaxCapacity = maxCapacity;
        }
    }
}
