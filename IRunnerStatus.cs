using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonMarathonApp
{
    /**
     * IRunnerStatus interface contains an abstract calass for updating Runner status.
     */
    internal interface IRunnerStatus
    {
        int updateRunnerStatus();
    }
}
