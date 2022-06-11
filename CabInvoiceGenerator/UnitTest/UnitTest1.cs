using NUnit.Framework;

namespace CabInvoiceGenerator
{
    public class Tests
    {
        CabInvoice cabInvoice;

        [SetUp]
        public void Setup()
        {
            cabInvoice = new CabInvoice();
        }
        [Test]
        [TestCase(5, 3)]
        public void GivenTimeAndDistance_calculateFare(double distance, double time)
        {
            int expected = 53;
            Ride ride = new Ride(distance, time);
            Assert.AreEqual(expected, cabInvoice.FareForSingleRide(ride));
        }

        [Test]
        public void InvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-3,2);
            CustomException customException = Assert.Throws<CustomException>(() => cabInvoice.FareForSingleRide(ride));
            Assert.AreEqual(customException.Type, CustomException.ExceptionType.Invalid_distance);
        }
    }
}