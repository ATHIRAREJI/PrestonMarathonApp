using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonMarathonApp
{
    internal interface IVolunteer
    {
        int VolTypeId { get; set; }
        string VolunteeringType { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }    
    }
}
