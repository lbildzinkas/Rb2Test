using System;
using System.Collections.Generic;
using System.Linq;
using Rb2Test.Domain.Model;

namespace Rb2Test.Domain.Service
{
    public class TrackCalculatorService : ITrackCalculatorService
    {   
        public Track[] CalculateTracks(IList<Talk> talks)
        {
            DateTime startTime = DateTime.MinValue; 
            var trackes = new List<Track>();
            uint trackId = 1;
            var track = new Track
            {
                Id = trackId,
                TrackedTalks = new List<TrackedTalk>()
            };
            
            var i = 0;
            
            //todo: refactor the algorithm to find the best combination for perfect schedule
            while (i < talks.Count)
            {
                var talk = talks[i];
                var trackedTalk = new TrackedTalk();
                
                if (startTime == DateTime.MinValue)
                {
                    startTime = new DateTime(1, 1, 1, 9, 0, 0);
                }
                
                var nextEventTime = startTime.AddMinutes(talk.Length);
                    
                if (nextEventTime.Hour > 16 && nextEventTime.Hour <= 17)
                {
                    //todo: refactor this to a fluent interface using builder pattern
                    trackedTalk.Time = startTime.Hour < 16 ? new DateTime(1, 1, 1, 16, 0, 0) : startTime;
                    trackedTalk.Title = "Networking Event";
                    trackedTalk.Length = 60;
                    
                    track.TrackedTalks.Add(trackedTalk);
                    trackes.Add(track);
                    trackId++;
                    track = new Track
                    {
                        Id = trackId,
                        TrackedTalks = new List<TrackedTalk>()
                    };
                    startTime = new DateTime(1, 1, 1, 9, 0, 0);
                }
                else if (nextEventTime.Hour > 12 && nextEventTime.Hour < 13)
                {
                    //todo: refactor this to a fluent interface using builder pattern
                    trackedTalk.Time = new DateTime(1, 1, 1, 12, 0, 0);
                    trackedTalk.Length = 60;
                    trackedTalk.Title = "Lunch";
                    track.TrackedTalks.Add(trackedTalk);
                    
                    startTime = new DateTime(1, 1, 1, 13, 0, 0);
                }
                else
                {
                    trackedTalk.Time = startTime;
                    trackedTalk.Title = talk.Title;
                    trackedTalk.Length = talk.Length;
                    
                    track.TrackedTalks.Add(trackedTalk);
                    
                    startTime = startTime.AddMinutes(talk.Length);
                    i++;
                }
            }
            
            if (startTime.Hour <= 16)
            {
                //todo: refactor this to a fluent interface using builder pattern
                var trackedTalk = new TrackedTalk
                {
                    Time = startTime.Hour < 16 ? new DateTime(1, 1, 1, 16, 0, 0) : startTime,
                    Title = "Networking Event",
                    Length = 60
                };

                track.TrackedTalks.Add(trackedTalk);
                trackes.Add(track);
            }
            
            return trackes.ToArray();
        }
    }
}