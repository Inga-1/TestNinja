using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {

            //Arrange 

            var reservation = new Reservation();

            //Act

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert 
            Assert.IsTrue(result);

        }

        [Test]

        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange 
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            //Act 

            var result = reservation.CanBeCancelledBy(user);

            //Assert

            Assert.IsTrue(result);

            /* different syntax for assertions using Nunit 
             * 
             * Assert.That(result, Is.True);
             * Assert.That(result == True);
             */
        }

        [Test]

        public void CannotBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}