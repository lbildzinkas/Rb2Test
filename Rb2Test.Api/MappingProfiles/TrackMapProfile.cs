using AutoMapper;
using Rb2Test.Api.Controllers;
using Rb2Test.Api.ViewModels;
using Rb2Test.Domain.Model;

namespace Rb2Test.Api.MappingProfiles
{
    public class TrackMapProfile : Profile
    {
        public TrackMapProfile()
        {
            CreateMap<Talk, TalkViewModel>()
                .ReverseMap();

            CreateMap<Track, TrackViewModel>();
            
            CreateMap<TrackedTalk, TrackedTalkViewModel>()
                .ForMember(t => t.Time, ex => ex.MapFrom(opt => opt.Time.ToShortTimeString()));
        }
    }
}