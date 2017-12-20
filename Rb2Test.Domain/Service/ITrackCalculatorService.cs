using System.Collections.Generic;
using Rb2Test.Domain.Model;

namespace Rb2Test.Domain.Service
{
    public interface ITrackCalculatorService
    {
        Track[] CalculateTracks(IList<Talk> talks);
    }
}