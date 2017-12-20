using System.Collections.Generic;
using Rb2Test.Domain.Model;

namespace Rb2Test.Service
{
    public interface ITrackService
    {
        Track[] FormatTalksIntoTracks(IList<Talk> talks);
    }
}