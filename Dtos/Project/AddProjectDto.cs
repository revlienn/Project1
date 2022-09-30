using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Dtos.Project
{
    public class AddProjectDto
    {
        public string Name { get; set; }=string.Empty;
        public int AccAmount { get; set; }=int.MinValue;
        public Models.Contact? MainContact { get; set; }=null;
        public List<Models.Staff>? Staffs { get; set; }=null;
    }
}