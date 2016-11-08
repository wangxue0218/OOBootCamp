using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OOBootCamp
{
    public class ParkingLotFacts_lesson3
    {
        [Fact]
        public void should_park_the_car_to_the_only_one_parking_log_and_then_pick_the_car_from_the_parking_lot()
        {
            var parkingLogs = new List<ParkingLog>();
            var parkingLog = new ParkingLog(1);
            parkingLogs.Add(parkingLog);
            var smartBoy = new SmartBoy(parkingLogs);
            var car = new Car("12345");
            var parkCarId = smartBoy.Park(car);
            Assert.Same(car, parkingLog.Pick(parkCarId));
        }

        [Fact]
        public void should_fail_to_park_the_car_to_the_only_one_parking_log_with_no_free()
        {
            var parkingLogs = new List<ParkingLog>();
            var parkingLog = new ParkingLog();
            parkingLogs.Add(parkingLog);
            var smartBoy = new SmartBoy(parkingLogs);
            var car = new Car("12345");
            Assert.Equal("The Parking Lot is full, can't park any more!", smartBoy.Park(car));
        }

        [Fact]
        public void should_park_the_car_to_the_parking_log_with_more_free()
        {
            var parkingLogs = new List<ParkingLog>();
            var parkingLog1 = new ParkingLog(1);
            var parkingLog2 = new ParkingLog(2);
            parkingLogs.Add(parkingLog1);
            parkingLogs.Add(parkingLog2);
            var smartBoy = new SmartBoy(parkingLogs);
            var car = new Car("12345");
            var parkCarId = smartBoy.Park(car);
            Assert.Equal(null, parkingLog1.Pick(parkCarId));
            Assert.Same(car, parkingLog2.Pick(parkCarId));
        }

        [Fact]
        public void should_fail_to_park_the_car_when_the_parking_lot_are_all_unavailable()
        {
            var parkingLogs = new List<ParkingLog>();
            var parkingLog1 = new ParkingLog();
            var parkingLog2 = new ParkingLog();
            parkingLogs.Add(parkingLog1);
            parkingLogs.Add(parkingLog2);
            var smartBoy = new SmartBoy(parkingLogs);
            var car = new Car("12345");
            Assert.Equal("The Parking Lot is full, can't park any more!", smartBoy.Park(car));
        }

        [Fact]
        public void should_park_the_car_to_the_first_parking_log_when_the_two_has_same_free()
        {
            var parkingLogs = new List<ParkingLog>();
            var parkingLog1 = new ParkingLog(1);
            var parkingLog2 = new ParkingLog(1);
            parkingLogs.Add(parkingLog1);
            parkingLogs.Add(parkingLog2);
            var smartBoy = new SmartBoy(parkingLogs);
            var car = new Car("12345");
            var parkCarId = smartBoy.Park(car);
            Assert.Equal(car, parkingLog1.Pick(parkCarId));
            Assert.Same(null, parkingLog2.Pick(parkCarId));
        }
    }
}
