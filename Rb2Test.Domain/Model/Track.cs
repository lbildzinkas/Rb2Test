using System;
using System.Collections;
using System.Collections.Generic;

namespace Rb2Test.Domain.Model
{
    public class Track
    {
        private const ushort MorningLength = 180;
        private const ushort AfternoonLength = 240;
        private const int LightningLength = 5;
        private const string LightningTalk = "lightning";
        private readonly TrackedTalk _lunchTalk = new TrackedTalk() {Length = 60, Time = new DateTime(1, 1, 1, 12, 0, 0), Title = "Lunch" };
        private readonly TrackedTalk _networkingEventTalk = new TrackedTalk() { Length = 60, Time = new DateTime(1, 1, 1, 16, 0, 0), Title = "Networking Event" };
        private readonly DateTime _startMorning = new DateTime(1, 1, 1, 9, 0, 0);
        private readonly DateTime _startAfternoon = new DateTime(1, 1, 1, 13, 0, 0);

        private readonly IList<TrackedTalk> _morning;
        private readonly IList<TrackedTalk> _afternoon;

        private int _currentMorning;
        private int _currentAfternoon;
        private DateTime _currentMorningTime;
        private DateTime _currentAfternoonTime;

        public Track()
        {
            _morning = new List<TrackedTalk>();
            _afternoon = new List<TrackedTalk>();
            _currentMorning = MorningLength;
            _currentAfternoon = AfternoonLength;
            _currentMorningTime = _startMorning;
            _currentAfternoonTime = _startAfternoon;
        }

        public uint Id { get; set; }

        public IList<TrackedTalk> TrackedTalks => GetTrackedTalks();

        private IList<TrackedTalk> GetTrackedTalks()
        {
            var trackedTalks = new List<TrackedTalk>();
            trackedTalks.AddRange(_morning);
            trackedTalks.Add(_lunchTalk);
            trackedTalks.AddRange(_afternoon);
            trackedTalks.Add(GetNetworkingEvent());

            return trackedTalks;
        }

        private TrackedTalk GetNetworkingEvent()
        {
            if (_currentAfternoonTime.Hour <= 17 && _currentAfternoonTime.Hour >= 16)
            {
                _networkingEventTalk.Time = _currentAfternoonTime;
            }

            return _networkingEventTalk;
        }

        public bool AddTalk(Talk talk)
        {
            var availability = CheckAvailability(talk.Length);

            switch (availability)
            {
                case Availability.Morning:
                    Add(talk, ref _currentMorning, ref _currentMorningTime, _morning);
                    break;
                case Availability.Afternoon:
                    Add(talk, ref _currentAfternoon, ref _currentAfternoonTime, _afternoon);
                    break;
                case Availability.Full:
                    return false;
            }

            return true;
        }

        private void Add(Talk talk, ref int current, ref DateTime currenTime, IList<TrackedTalk> talkList)
        {
            talkList.Add(new TrackedTalk()
            {
                Length = talk.Length,
                Time = currenTime,
                Title = talk.Title
            });

            if(!talk.Title.ToLower().Contains(LightningTalk))
                AdjustPeriod(talk.Length, ref current, ref currenTime);
            else
                AdjustPeriod(LightningLength, ref current, ref currenTime);
        }

        private void AdjustPeriod(int length, ref int current, ref DateTime currenTime)
        {
            current -= length;
            currenTime = currenTime.AddMinutes(length);
        }

        private Availability CheckAvailability(int length)
        {
            if (_currentMorning >= length)
            {
                return Availability.Morning;
            }

            if (_currentAfternoon >= length)
            {
                return Availability.Afternoon;
            }

            return Availability.Full;
        }
    }

    internal enum Availability
    {
        Morning,
        Afternoon,
        Full
    }
}