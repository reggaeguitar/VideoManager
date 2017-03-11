using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using VideoManager.Utility;
using VideoManagerDomain;
using VideoServices;

namespace VideoManager.Controllers
{
    public class VideoController : ApiController
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IConnectionStringManager _connStrMan;

        public VideoController(
            IVideoRepository videoRepository,
            IConnectionStringManager connStrMan)
        {
            _videoRepository = videoRepository;
            _connStrMan = connStrMan;
        }

        [HttpGet]
        [Route("api/videos")]
        public JsonResult<ICollection<VideoDto>> GetAllVideos()
        {

            var connStrName = _connStrMan.GetConnStrName();
            var ret = _videoRepository.LoadAllVideos(connStrName);
#if DEBUG
            ret = ret.Take(100).ToList();
#endif
            return Json(ret);
        }        

        [HttpGet]
        [Route("api/increment/{videoId}")]
        public void IncrementVisitCount(int videoId)
        {
            var connStrName = _connStrMan.GetConnStrName();
           _videoRepository.IncrementVisitCount(connStrName, videoId);
        }

        [HttpGet]
        [Route("api/delete/{videoId}")]
        public void DeleteVideo(int videoId)
        {
            var connStrName = _connStrMan.GetConnStrName();
            _videoRepository.DeleteVideo(connStrName, videoId);
        }
    }
}