using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Contact> Contacts  {get; set; }
        public List<Project> Projects { get; set; }
    }
}