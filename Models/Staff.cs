using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Staff
    {
        public int Id { get; set; }=1;
        [Required]
        public string Name { get; set; }="Jane Doe";
        public string Email { get; set; }="test@companyname.com";

    }
}