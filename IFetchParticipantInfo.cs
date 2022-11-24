using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestonMarathonApp
{
    internal interface IFetchParticipantInfo<T>
    {
        List<T> getListOfParticipants();
        List<T> getParticipantInfo();

    }
}
