using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rb2Test.Api.ViewModels;
using Rb2Test.Domain.Model;
using Rb2Test.Service;

namespace Rb2Test.Api.Controllers
{
    [Route("/api/meeting/track")]
    public class MeetingController : Controller
    {
        private readonly ITrackService _trackService;
        private readonly ILogger<MeetingController> _logger;
        private readonly IMapper _mapper;

        public MeetingController(ITrackService trackService, ILogger<MeetingController> logger, IMapper mapper)
        {
            _trackService = trackService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [DisableCors]
        public IActionResult Post([FromBody] IList<TalkViewModel> talks)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
                var domainTalks = _mapper.Map<IList<TalkViewModel>, IList<Talk>>(talks);
                var trackes = _trackService.FormatTalksIntoTracks(domainTalks);
                
                return Ok(_mapper.Map<IList<Track>, IList<TrackViewModel>>(trackes));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest();
            }
        }
    }
}