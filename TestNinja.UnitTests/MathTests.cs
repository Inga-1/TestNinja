using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math; //stex stexcum enq private attribute, vory chenq kara reuse anenq amen methodum bayc karan   reuse anenq SetUpum 

        [SetUp]

        public void SetUp()
        {
            _math = new Math();
        }
        [Test]

        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));

        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            //Act 
            var result = _math.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]

        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5); //we are using 5, not 1, so our array can have at least a couple of elements vor testy imast unena 

            //Most general way 
            //This is just to make sure that the method returns at least something 
            //Assert.That(result, Is.Not.Empty);

            //A bit more specific
            //doesnt give much confidence, cuz it can literally just be 3 1s in the array 
            //Assert.That(result.Count, Is.EqualTo(3));

            //aveli specific
            /*Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5)); */

            //es amen inchy aveli havaq u clean grelu hamar, yndameny ogtagorcum enq hetevyaly
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Assert.That(result, Is.Ordered);

            //Assert.That(result, Is.Unique);

        }

        [Test]

        public void GetOddNumber_LimitIsLessThanZero_ReturnEmptyArray()
        {
            var result = _math.GetOddNumbers(-5);

            Assert.That(result, Is.Empty);
        }

        [Test]

        public void GetOddNumber_LimitIsZero_ReturnEmptyArray()
        {
            var result = _math.GetOddNumbers(0);

            Assert.That(result, Is.Empty);
        }

    }
}
