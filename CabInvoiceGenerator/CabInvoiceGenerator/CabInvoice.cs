using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoice
    {
        double Cost_per_km;
        double Cost_per_min;
        double min_fare;
        double total_fare;
        public int RideCount;
        public double AverageFare;

        public CabInvoice()
        {
            this.Cost_per_km = 10;
            this.Cost_per_min = 1;
            this.min_fare = 5;
            this.RideCount = 0;
        }

        public double FareForSingleRide(Ride ride)
        {
            if(ride.distance<0)
            {
                throw new CustomException(CustomException.ExceptionType.Invalid_distance, "Invalid Distance");
            }
            if(ride.time<0)
            {
                throw new CustomException(CustomException.ExceptionType.Invalid_time, "Invalid Time");
            }
            return Math.Max(min_fare, ride.distance * Cost_per_km + ride.time * Cost_per_min);
        }


        public double TotalFareForMultipleRideReturn(List<Ride> rides)
        {
            foreach (Ride ride in rides)
            {
                total_fare += FareForSingleRide(ride);
                RideCount += 1;
            }
            AverageFare = total_fare / RideCount;
            return total_fare;
        }
    }
}
