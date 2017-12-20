using System.Collections.Generic;

namespace Rb2Test.Domain.Model
{
    public class Track
    {
        public uint Id { get; set; }
        public IList<TrackedTalk> TrackedTalks { get; set; }
    }
}