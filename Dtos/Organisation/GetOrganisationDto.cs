using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Dtos.Organisation
{
    public class GetOrganisationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Phone { get; set; }=string.Empty;
        public List<Models.Contact>? Contacts  {get; set; }
        public List<Models.Project>? Projects { get; set; }
    }
}