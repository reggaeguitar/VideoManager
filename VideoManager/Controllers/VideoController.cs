using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using VideoManager.EntityFramework;
using VideoManager.Utility;
using VideoServices;

namespace VideoManager.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
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

        //[HttpGet]
        //[Route("api/videos")]
        //public JsonResult<ICollection<Video>> GetAllVideos()
        //{
        //    var ret = _videoRepository.LoadAllVideos();
        //    return Json(ret);
        //}

        //[HttpGet]
        //[Route("api/increment/{videoId}")]
        //public void IncrementVisitCount(int videoId)
        //{
        //    _videoRepository.IncrementVisitCount(videoId);
        //}

        //[HttpGet]
        //[Route("api/delete/{videoId}")]
        //public void DeleteVideo(int videoId)
        //{
        //    _videoRepository.DeleteVideo(videoId);
        //}
    }
}