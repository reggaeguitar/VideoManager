using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using VideoManager.EntityFramework;
using VideoManagerDomain;
using VideoServices;

namespace VideoManager.Tests
{
    public class VideoRepositoryTests : BaseUnitTestClass
    {
        private VideoRepository GetSut(
            IVideoManagerContextFactory ctxFactory,
            IVideoDtoConverter videoDtoConverter)
        {
            return new VideoRepository(ctxFactory, videoDtoConverter);
        }

        //void DeleteVideo(int videoId);

        [Test]
        public void VideoRepository_IncrementVisitCount_IncrementsVisitCountCorrectly()
        {
            var a = GetRandom<Video>();
            // Arrange
            var dbInfo = SetUpFakeDb();
            var ctx = dbInfo.Item1;
            var ctxFactory = dbInfo.Item2;
            var connStrName = dbInfo.Item3;
            var videoDtoConverter = dbInfo.Item4;

            var videoId = GetRandomInt();
            var curVisitCount = GetRandomInt();

            var vid = GetFake<Video>();
            vid.VideoId = videoId;
            vid.VisitCount = curVisitCount;
            ctx.Video.Add(vid);

            var sut = GetSut(ctxFactory, videoDtoConverter);

            // Act
            sut.IncrementVisitCount(connStrName, videoId);

            // Assert
            var expected = curVisitCount + 1;
            Assert.AreEqual(expected, ctx.Video.Single(x => x.VideoId == videoId).VisitCount);
        }

        [Test]
        public void VideoRepository_CreateVideo_CreatesVideoCorrectly()
        {
            // Arrange
            var dbInfo = SetUpFakeDb();
            var ctx = dbInfo.Item1;
            var ctxFactory = dbInfo.Item2;
            var connStrName = dbInfo.Item3;
            var videoDtoConverter = dbInfo.Item4;

            var videoDto = GetFake<VideoDto>();
            var video = GetFake<Video>();
            A.CallTo(() => videoDtoConverter.VideoDtoToVideo(videoDto)).Returns(video);

            var sut = GetSut(ctxFactory, videoDtoConverter);

            // Act
            sut.CreateVideo(connStrName, videoDto);

            // Assert
            Assert.AreEqual(video, ctx.Video.Single());
        }

        [Test]
        public void VideoRepository_LoadAllVideos_LoadsVideosCorrectly()
        {
            // Arrange
            var dbInfo = SetUpFakeDb();
            var ctx = dbInfo.Item1;
            var ctxFactory = dbInfo.Item2;
            var connStrName = dbInfo.Item3;
            var videoDtoConverter = dbInfo.Item4;

            var vids = new List<Video>
            {
                GetFake<Video>(),
                GetFake<Video>(),
                GetFake<Video>()
            };
            var vidDtos = new List<VideoDto>
            {
                GetFake<VideoDto>(),
                GetFake<VideoDto>(),
                GetFake<VideoDto>()
            };
            for (int i = 0; i < vids.Count; i++)
            {
                ctx.Video.Add(vids[i]);
                A.CallTo(() => videoDtoConverter.VideoToVideoDto(vids[i])).Returns(vidDtos[i]);
            }            

            var sut = GetSut(ctxFactory, videoDtoConverter);

            // Act
            var res = sut.LoadAllVideos(connStrName);

            // Assert
            CollectionAssert.AreEqual(vidDtos, res);
        }

        [Test]
        public void VideoRepository_LoadVideo_LoadsVideoCorrectly()
        {
            // Arrange
            var dbInfo = SetUpFakeDb();
            var ctx = dbInfo.Item1;
            var ctxFactory = dbInfo.Item2;
            var connStrName = dbInfo.Item3;
            var videoDtoConverter = dbInfo.Item4;

            var vidId = GetRandomInt();

            var vidToFind = GetFake<Video>();
            vidToFind.VideoId = vidId;
            ctx.Video.Add(vidToFind);
            var expected = GetFake<VideoDto>();
            A.CallTo(() => videoDtoConverter.VideoToVideoDto(vidToFind)).Returns(expected);

            var sut = GetSut(ctxFactory, videoDtoConverter);

            // Act
            var res = sut.LoadVideo(connStrName, vidId);

            // Assert
            Assert.AreEqual(expected, res);
        }

        [Test]
        public void VideoRepository_EditVideo_EditsVideoCorrectly()
        {
            // Arrange
            // Arrange
            var dbInfo = SetUpFakeDb();
            var ctx = dbInfo.Item1;
            var ctxFactory = dbInfo.Item2;
            var connStrName = dbInfo.Item3;
            var videoDtoConverter = dbInfo.Item4;

            var video = GetFake<Video>();
            video.VideoId = GetRandomInt();

            var videoDto = GetFake<VideoDto>();
            videoDto.VideoId = video.VideoId;

            A.CallTo(() => videoDtoConverter.VideoDtoToVideo(videoDto)).Returns(video);            

            var sut = GetSut(ctxFactory, videoDtoConverter);

            // Act
            sut.EditVideo(connStrName, videoDto);

            // Assert
            Assert.AreEqual(video, ctx.Video.Single());
        }
        
        [Test]
        public void VideoRepository_DeleteVideo_DeletesVideoCorrectly()
        {
            // Arrange            
            var dbInfo = SetUpFakeDb();
            var ctx = dbInfo.Item1;
            var ctxFactory = dbInfo.Item2;
            var connStrName = dbInfo.Item3;
            var videoDtoConverter = dbInfo.Item4;

            var videoId = GetRandomInt();
            var video = GetFake<Video>();
            video.VideoId = videoId;
            ctx.Video.Add(video);

            var sut = GetSut(ctxFactory, videoDtoConverter);

            // Act
            sut.DeleteVideo(connStrName, videoId);

            // Assert
            Assert.AreEqual(0, ctx.Video.Count());
        }

        private Tuple<IVideoManagerContext, IVideoManagerContextFactory, string, IVideoDtoConverter>  SetUpFakeDb()
        {
            // Create fakes
            var ctxFactory = GetFake<IVideoManagerContextFactory>();
            var ctx = GetFake<IVideoManagerContext>();
            var videoDtoConverter = GetFake<IVideoDtoConverter>();         

            var connStrName = GetRandomString();
            A.CallTo(() => ctxFactory.Create(connStrName)).Returns(ctx);

            // New up fake tables
            ctx.Actor = new FakeDbSet<Actor>();
            ctx.Tag = new FakeDbSet<Tag>();
            ctx.Video = new FakeDbSet<Video>();

            var ret = Tuple.Create(ctx, ctxFactory, connStrName, videoDtoConverter);
            return ret;
        }
    }
}
