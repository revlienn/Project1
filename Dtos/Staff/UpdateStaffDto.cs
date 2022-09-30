using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Dtos.Staff
{
    public class UpdateStaffDto
    {
        public int Id { get; set; }=1;
        public string Name { get; set; }="Jane Doe";
        public string Email { get; set; }="test@companyname.com";
    }
}