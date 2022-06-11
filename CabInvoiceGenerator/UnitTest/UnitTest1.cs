using NUnit.Framework;
using System.Collections.Generic;

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

        // UC 1: Calculate total fare for the journey 
        [Test]
        [TestCase(6, 4)]
        public void GivenTimeAndDistance_calculateFare(double distance, double time)
        {
            int expected = 64;
            Ride ride = new Ride(distance, time);
            Assert.AreEqual(expected, cabInvoice.FareForSingleRide(ride));
        }

        // TC 1.1: Check for invalid distance
        [Test]
        public void InvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-3,2);
            CustomException customException = Assert.Throws<CustomException>(() => cabInvoice.FareForSingleRide(ride));
            Assert.AreEqual(customException.Type, CustomException.ExceptionType.Invalid_distance);
        }

        // TC 1.2: Check for invalid time
        [Test]
        public void InvalidTime_ThrowException()
        {
            Ride ride = new Ride(3, -2);
            CustomException customException = Assert.Throws<CustomException>(() => cabInvoice.FareForSingleRide(ride));
            Assert.AreEqual(customException.Type, CustomException.ExceptionType.Invalid_time);
        }

        // UC 2: Check for multiple rides and aggregate fare
        [Test]
        public void GivenListofRides_CalculateFareForMultipleRides()
        {
            Ride ride_1 = new Ride(3, 1);
            Ride ride_2 = new Ride(4, 6);

            List<Ride> ride = new List<Ride>();
            ride.Add(ride_1);
            ride.Add(ride_2);
            Assert.AreEqual(77, cabInvoice.TotalFareForMultipleRideReturn(ride));
        }
    }
}