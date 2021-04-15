using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
