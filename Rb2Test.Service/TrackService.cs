using System.Collections.Generic;
using Rb2Test.Domain.Model;
using Rb2Test.Domain.Service;

namespace Rb2Test.Service
{
    public class TrackService : ITrackService
    {
        private readonly ITrackCalculatorService _trackCalculatorService;

        public TrackService(ITrackCalculatorService trackCalculatorService)
        {
            _trackCalculatorService = trackCalculatorService;
        }

        public Track[] FormatTalksIntoTracks(IList<Talk> talks)
        {
            return _trackCalculatorService.CalculateTracks(talks);
        }
    }
}