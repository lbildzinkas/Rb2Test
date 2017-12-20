using System.Collections.Generic;
using Rb2Test.Api.ViewModels;

namespace Rb2Test.Api.Controllers
{
    public class TrackViewModel
    {
        public uint Id { get; set; }
        public IList<TrackedTalkViewModel> TrackedTalks { get; set; }
    }
}