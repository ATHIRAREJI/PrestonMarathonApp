using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonMarathonApp
{
    /**
     * IVolunteer interface contains properities for both volunteer and volunteerInfo
     */
    internal interface IVolunteer
    {
        int VolTypeId { get; set; }
        string VolunteeringType { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }    
    }
}
