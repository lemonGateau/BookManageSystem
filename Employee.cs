using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManageSystem
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("user_id")] // DBのカラム名に合わせて指定
        public int UserId { get; set; }

        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [Column("prefecture")]
        public string? Prefecture { get; set; } = null!;

        [Column("city")]
        public string? City { get; set; } = null!;

        [Column("address")]
        public string? Address { get; set; } = null!;

        [Column("tel")]
        public string? Tel { get; set; } = null!;

        [Column("email")]
        public string? Email { get; set; } = null!;

        [Column("office_id")]
        public int OfficeId { get; set; }

        [Column("password")]
        public string Password { get; set; } = null!;

        [ForeignKey("OfficeId")]
        public virtual Office Office { get; set; } = null!;

        public Employee()
        {

        }

        public Employee(int userId, string lastName, string firstName, string prefecture, string city, string address, string tel, string email, int officeId, string password)
        {
            UserId = userId;
            LastName = lastName;
            FirstName = firstName;
            Prefecture = prefecture;
            City = city;
            Address = address;
            Tel = tel;
            Email = email;
            OfficeId = officeId;
            Password = password;
        }
    }
}
