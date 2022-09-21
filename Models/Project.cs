using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Project
    {
        public int Id { get; set; }=int.MinValue;
        public string Name { get; set; }=string.Empty;
        public int AccAmount { get; set; }=int.MinValue;
        public Contact? MainContact { get; set; }
        public List<Staff>? Staffs { get; set; }
    }
}