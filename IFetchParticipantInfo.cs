
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonMarathonApp
{
    /**
     * IFetchParticipantInfo contains two abstract methods for getting participant details.
     */
    internal interface IFetchParticipantInfo<T>
    {
        List<T> getListOfParticipants();
        List<T> getParticipantInfo();

    }
}
