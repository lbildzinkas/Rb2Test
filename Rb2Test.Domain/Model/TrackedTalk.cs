using System;

namespace Rb2Test.Domain.Model
{
    public class TrackedTalk
    {
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public ushort Length { get; set; }
    }
}