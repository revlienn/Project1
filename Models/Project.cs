using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccAmount { get; set; }
        public int MainContact { get; set; }
        public List<Staff> Staffs { get; set; }
    }
}