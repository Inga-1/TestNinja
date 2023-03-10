using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]

        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]

        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //if we pass "", "" as arguments in the lambda expression for the mock, the expected behavior
            //will NOT happen, unless we have exactly "", ""
            //using It.IsAny instead of "http://example.com/customer/installer", since we might not even know 
            //what exactly that string is
            _fileDownloader.Setup(fd => 
                 fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        [Test]

        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}
