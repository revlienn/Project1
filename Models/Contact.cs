using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Contact
    {
        public int Id { get; set; }=int.MinValue;
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }=string.Empty;
        public int OrganisationId { get; set; }=int.MinValue;
    }
}