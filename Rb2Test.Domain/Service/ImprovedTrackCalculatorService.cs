using System.Collections.Generic;
using Rb2Test.Domain.Model;

namespace Rb2Test.Domain.Service
{
    public class ImprovedTrackCalculatorService : ITrackCalculatorService
    {
        public Track[] CalculateTracks(IList<Talk> talks)
        {
            uint trackId = 1;
            var tracks = new List<Track>();
            Track track = new Track(){Id = trackId };
            tracks.Add(track);

            foreach (var talk in talks)
            {
                if (!track.AddTalk(talk))
                {
                    trackId++;
                    track = new Track() { Id = trackId }; ;
                    tracks.Add(track);
                }
            }

            return tracks.ToArray();
        }
    }
}