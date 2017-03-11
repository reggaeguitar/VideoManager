using FakeItEasy;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http.Results;
using VideoManager.Controllers;
using VideoManager.Utility;
using VideoManagerDomain;
using VideoServices;

namespace VideoManager.Tests
{
    public class VideoControllerTests : BaseUnitTestClass
    {
        private VideoController GetSut(
            IVideoRepository videoRepository,
            IConnectionStringManager connStrMan)
        {
            return new VideoController(videoRepository, connStrMan);
        }

        [Test]
        public void VideoControllerTests_GetAllVideos_GetsAllVideosCorrectly()
        {
            // Arrange
            var videoRepository = GetFake<IVideoRepository>();
            var connStrMan = GetFake<IConnectionStringManager>();

            var connStrName = GetRandom<string>();
            A.CallTo(() => connStrMan.GetConnStrName()).Returns(connStrName);

            var expected = GetFake<ICollection<VideoDto>>();
            A.CallTo(() => videoRepository.LoadAllVideos(connStrName)).Returns(expected);

            var sut = GetSut(videoRepository, connStrMan);

            // Act
            var res = sut.GetAllVideos();

            // Assert
            Assert.AreEqual(expected, res);
        }

        [Test]
        public void VideoController_DeleteVideo_DeletesVideoCorrectly()
        {
            // Arrange
            var videoRepository = GetFake<IVideoRepository>();
            var connStrMan = GetFake<IConnectionStringManager>();

            var videoId = GetRandomInt();

            var connStrName = GetRandom<string>();
            A.CallTo(() => connStrMan.GetConnStrName()).Returns(connStrName);

            var expected = GetFake<ICollection<VideoDto>>();            

            var sut = GetSut(videoRepository, connStrMan);

            // Act
            sut.DeleteVideo(videoId);

            // Assert
            A.CallTo(() => videoRepository.DeleteVideo(connStrName, videoId)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void VideoController_IncrementVisitCount_IncrementsVisitCountProperly()
        {
            // Arrange
            var videoRepository = GetFake<IVideoRepository>();
            var connStrMan = GetFake<IConnectionStringManager>();

            var sut = GetSut(videoRepository, connStrMan);

            var connStrName = GetRandom<string>();
            A.CallTo(() => connStrMan.GetConnStrName()).Returns(connStrName);

            var videoId = GetRandomInt();

            // Act
            sut.IncrementVisitCount(videoId);

            // Assert
            A.CallTo(() => videoRepository.IncrementVisitCount(connStrName, videoId))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
