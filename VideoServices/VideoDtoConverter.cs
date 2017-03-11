using System;
using System.Collections.Generic;
using System.Linq;
using VideoManager.EntityFramework;
using VideoManagerDomain;

namespace VideoServices
{
    public class VideoDtoConverter : IVideoDtoConverter
    {
        private readonly IActorDtoConverter _actorDtoConverter;
        private readonly ITagDtoConverter _tagDtoConverter;

        public VideoDtoConverter(
            IActorDtoConverter actorDtoConverter,
            ITagDtoConverter tagDtoConverter)
        {
            _actorDtoConverter = actorDtoConverter;
            _tagDtoConverter = tagDtoConverter;
        }

        public Video VideoDtoToVideo(VideoDto videoDto)
        {
            throw new NotImplementedException();
        }

        public VideoDto VideoToVideoDto(Video video)
        {
            var actors = new List<ActorDto>();
            foreach (var actor in video.Actor)
            {
                actors.Add(_actorDtoConverter.ActorToActorDto(actor));
            }
            var tags = new List<TagDto>();
            foreach (var tag in video.Tag)
            {
                tags.Add(_tagDtoConverter.TagToTagDto(tag));
            }
            var ret = new VideoDto(
                actors,
                video.DateAdded,
                video.VideoId,
                video.LastVisited,
                video.Points,
                video.Title,
                tags,
                video.Url,
                video.VisitCount);
            return ret;
        }
    }
}
