using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp
{
    public class SmartBoy
    {
        private List<ParkingLog> parkingLogs;

        public SmartBoy(List<ParkingLog> parkingLogs)
        {
            this.parkingLogs = parkingLogs;
        }

        public string Park(Car car)
        {
            parkingLogs = parkingLogs.OrderByDescending(p => p.number).ToList();
            return parkingLogs[0].Park(car);
        }

        public Car Pick(string carId)
        {
            return parkingLogs[0].Pick(carId);
        }
    }
}