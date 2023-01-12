using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            //Arrange
            var formatter = new HtmlFormatter();

            //Act
            var result = formatter.FormatAsBold("abc");

            //Assert

            //Specific assertion 
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //More general way 

            /*Assert.That(result, Does.StartWith("<strong>")); //kara menak skizby lini bold u pass ani bayc sxal lini
            Assert.That(result, Does.EndWith("<strong>")); //kara skizbn u verjy ok lini bayc contenty hashvi charni
            Assert.That(result, Does.Contain("abc")); */

        }
    }
}
