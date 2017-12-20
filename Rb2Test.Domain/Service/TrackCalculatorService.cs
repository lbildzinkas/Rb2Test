using System;
using System.Collections.Generic;
using System.Linq;
using Rb2Test.Domain.Model;

namespace Rb2Test.Domain.Service
{
    public class TrackCalculatorService : ITrackCalculatorService
    {
        private readonly IConfigurationService _configurationService;

        public TrackCalculatorService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        
        public Track[] CalculateTracks(IList<Talk> talks)
        {
            DateTime startTime = DateTime.MinValue; 
            var trackes = new List<Track>();
            var track = new Track
            {
                TrackedTalks = new List<TrackedTalk>()
            };
            var i = 0;
            
            while (i < talks.Count-1)
            {
                i++;
                var talk = talks[i];
                var trackedTalk = new TrackedTalk();
                
                if (startTime == DateTime.MinValue)
                {
                    startTime = new DateTime(1, 1, 1, 9, 0, 0);
                }
                
                var nextEventTime = startTime.AddMinutes(talk.Length);
                    
                if (nextEventTime.Hour >= 16 && nextEventTime.Hour < 17)
                {
                    //refactor this to a fluent interface using builder pattern
                    trackedTalk.Time = startTime.Hour < 16 ? new DateTime(1, 1, 1, 16, 0, 0) : startTime;
                    trackedTalk.Title = "Networking Event";
                    trackedTalk.Length = 60;
                    
                    track.TrackedTalks.Add(trackedTalk);
                    trackes.Add(track);
                    track = new Track
                    {
                        TrackedTalks = new List<TrackedTalk>()
                    };
                    startTime = new DateTime(1, 1, 1, 9, 0, 0);
                    i--;
                }
                else if (nextEventTime.Hour >= 12 && nextEventTime.Hour < 13)
                {
                    trackedTalk.Time = new DateTime(1, 1, 1, 12, 0, 0);
                    trackedTalk.Length = 60;
                    trackedTalk.Title = "Lunch";
                    track.TrackedTalks.Add(trackedTalk);
                    
                    startTime = new DateTime(1, 1, 1, 13, 0, 0);
                    i--;
                }
                else
                {
                    trackedTalk.Time = startTime;
                    trackedTalk.Title = talk.Title;
                    trackedTalk.Length = talk.Length;
                    
                    track.TrackedTalks.Add(trackedTalk);
                    
                    startTime = startTime.AddMinutes(talk.Length);
                }
            }
            
            if (startTime.Hour <= 16)
            {
                var trackedTalk = new TrackedTalk();
                //refactor this to a fluent interface using builder pattern
                trackedTalk.Time = startTime.Hour < 16 ? new DateTime(1, 1, 1, 16, 0, 0) : startTime;
                trackedTalk.Title = "Networking Event";
                trackedTalk.Length = 60;
                    
                track.TrackedTalks.Add(trackedTalk);
                trackes.Add(track);
            }
            
            return trackes.ToArray();
        }
    }

    public interface IConfigurationService
    {
    }
}