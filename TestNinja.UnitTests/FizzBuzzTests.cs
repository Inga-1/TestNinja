using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [Test]
        public void GetOutput_DivisibleByThreeAndFive_ReturnsFizzBuzz()
        {
            //if the method is static, we do NOT need to define the var, we can simply use it as below

            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));

        }

        [Test]
        public void GetOutput_DivisibleByThree_ReturnsFizz()
        {

            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));

        }

        [Test]
        public void GetOutput_DivisibleByFive_ReturnsBuzz()
        {

            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));

        }

        [Test]
        public void GetOutput_NonDivisibleByThreeAndFive_ReturnsTheNumberToString()
        {

            var result = FizzBuzz.GetOutput(2);

            Assert.That(result, Is.EqualTo("2"));

        }
    }
}
