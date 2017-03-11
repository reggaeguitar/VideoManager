using System;
using System.Collections.Generic;
using System.Linq;
using VideoManager.EntityFramework;
using VideoManagerDomain;

namespace VideoServices
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IVideoManagerContextFactory _ctxFactory;
        private readonly IVideoDtoConverter _videoDtoConverter;

        public VideoRepository(
            IVideoManagerContextFactory ctxFactory,
            IVideoDtoConverter videoDtoConverter)
        {
            _ctxFactory = ctxFactory;
            _videoDtoConverter = videoDtoConverter;
        }

        public void CreateVideo(string connStrName, VideoDto videoDto)
        {
            var vid = _videoDtoConverter.VideoDtoToVideo(videoDto);
            using (var ctx = _ctxFactory.Create(connStrName))
            {
                ctx.Video.Add(vid);
                ctx.SaveChanges();
            }
        }

        public void DeleteVideo(string connStrName, int videoId)
        {
            throw new NotImplementedException();
        }

        public void EditVideo(string connStrName, VideoDto videoDto)
        {
            throw new NotImplementedException();
        }

        public void IncrementVisitCount(string connStrName, int videoId)
        {
            using (var ctx = _ctxFactory.Create(connStrName))
            {
                var vid = ctx.Video.Single(x => x.VideoId == videoId);
                ++vid.VisitCount;
                ctx.SaveChanges();
            }
        }

        public ICollection<VideoDto> LoadAllVideos(string connStrName)
        {
            var ret = new List<VideoDto>();
            using (var ctx = _ctxFactory.Create(connStrName))
            {
                var vids = ctx.Video.ToList();
                foreach (var vid in vids)
                {
                    var vidDto = _videoDtoConverter.VideoToVideoDto(vid);
                    ret.Add(vidDto);
                }
            }
            return ret;
        }

        public VideoDto LoadVideo(string connStrName, int videoId)
        {
            throw new NotImplementedException();
        }
    }
}
