using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using VideoManager.EntityFramework;
using VideoManagerDomain;
using VideoServices;

namespace VideoManager.Tests
{
    public class VideoDtoConverterTests : BaseUnitTestClass
    {
        private VideoDtoConverter GetSut(
            IActorDtoConverter actorDtoConverter,
            ITagDtoConverter tagDtoConverter)
        {
            return new VideoDtoConverter(actorDtoConverter, tagDtoConverter);
        }

        [Test]
        public void VideoDtoConverter_VideoToVideoDto_ConvertsCorrectly()
        {
            // Arrange
            var actorDtoConverter = GetFake<IActorDtoConverter>();
            var tagDtoConverter = GetFake<ITagDtoConverter>();

            var video = GetFake<Video>();

            var actor1 = GetFake<Actor>();
            var actor2 = GetFake<Actor>();
            video.Actor = new List<Actor> { actor1, actor2 };
            var actorDto1 = GetFake<ActorDto>();
            var actorDto2 = GetFake<ActorDto>();
            A.CallTo(() => actorDtoConverter.ActorToActorDto(actor1)).Returns(actorDto1);
            A.CallTo(() => actorDtoConverter.ActorToActorDto(actor2)).Returns(actorDto2);
            var expectedActors = new List<ActorDto> { actorDto1, actorDto2 };

            var tag1 = GetFake<Tag>();
            var tag2 = GetFake<Tag>();
            video.Tag = new List<Tag> { tag1, tag2 };
            var tagDto1 = GetFake<TagDto>();
            var tagDto2 = GetFake<TagDto>();
            A.CallTo(() => tagDtoConverter.TagToTagDto(tag1)).Returns(tagDto1);
            A.CallTo(() => tagDtoConverter.TagToTagDto(tag2)).Returns(tagDto2);
            var expectedTags = new List<TagDto> { tagDto1, tagDto2 };

            video.DateAdded = DateTime.Now;
            video.LastVisited = DateTime.Now.AddDays(-1);
            video.Points = GetRandomInt();
            video.Title = GetRandomString();
            video.Url = GetRandomString();
            video.VideoId = GetRandomInt();
            video.VisitCount = GetRandomInt();

            var sut = GetSut(actorDtoConverter, tagDtoConverter);

            // Act
            var res = sut.VideoToVideoDto(video);

            // Assert
            CollectionAssert.AreEqual(expectedActors, res.Actors);
            Assert.AreEqual(video.DateAdded.Date, res.DateAdded.Date);
            Assert.AreEqual(video.LastVisited.Value.Date, res.LastVisited.Value.Date);
            Assert.AreEqual(video.Points, res.Points);
            CollectionAssert.AreEqual(expectedTags, res.Tags);
            Assert.AreEqual(video.Title, res.Title);
            Assert.AreEqual(video.Url, res.Url);
            Assert.AreEqual(video.VideoId, res.VideoId);
            Assert.AreEqual(video.VisitCount, res.VisitCount);
        }

        [Test]
        public void VideoDtoConverter_VideoDtoToVideo_ConvertsCorrectly()
        {
            // Arrange
            var actorDtoConverter = GetFake<IActorDtoConverter>();
            var tagDtoConverter = GetFake<ITagDtoConverter>();

            var sut = GetSut(actorDtoConverter, tagDtoConverter);

            // Act

            // Assert
        }
    }
}
