using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IVideoRepository> _repository;
        private Mock<IFileReader> _fileReader;

        [SetUp]

        public void SetUp()
        {
            //we move these here as we will need them in other tests,
            //and this just helps keep the code cleaner 
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            //doing the same thing as the FakeFileReader would do 
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns(""); 

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]

        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _repository.Setup(r => r.GetUNprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringIdsOfUnprocessedVideos()
        {
            _repository.Setup(r => r.GetUNprocessedVideos()).Returns(new List<Video>
            {
                new Video{ Id = 1},
                new Video{ Id = 2},
                new Video{ Id = 3},
            }) ;

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
