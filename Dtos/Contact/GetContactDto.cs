using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Dtos.Contact
{
    public class GetContactDto
    {
        public int Id { get; set; }=1;
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }=string.Empty;
        public int OrganisationId { get; set; }=-1;
    }
}