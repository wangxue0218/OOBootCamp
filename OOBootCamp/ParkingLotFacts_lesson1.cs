using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OOBootCamp
{
    public class ParkingLotFacts_lesson1
    {
        [Fact]
        public void should_failed_to_park_when_the_parking_lot_has_no_free()
        {
            var parkingLog = new ParkingLog();
            var car = new Car("1");
            Assert.Equal("The Parking Lot is full, can't park any more!", parkingLog.Park(car));
        }

        [Fact]
        public void should_park_the_car_successfully()
        {
            var parkingLog = new ParkingLog(1);
            var car = new Car("1");
            Assert.Same("1", parkingLog.Park(car));
        }

        [Fact]
        public void should_pick_the_same_car_use_car_number_successfully()
        {
            var parkingLog = new ParkingLog(1);
            var car = new Car("1");
            string carId = parkingLog.Park(car);
            Assert.Same(car, parkingLog.Pick(carId));
        }

        [Fact]
        public void should_park_the_first_car_successfully_and_fail_to_park_the_second_car()
        {
            var parkingLog = new ParkingLog(1);
            var firstCar = new Car("1");
            var secondCar = new Car("2");
            Assert.Equal(firstCar.carId, parkingLog.Park(firstCar));
            Assert.Equal("The Parking Lot is full, can't park any more!", parkingLog.Park(secondCar));
            Assert.Same(firstCar, parkingLog.Pick(firstCar.carId));
        }

        [Fact]
        public void should_success_to_pick_the_parked_car_once_and_fail_to_pick_the_second_time()
        {
            var parkingLog = new ParkingLog(1);
            var firstCar = new Car("1");
            string carId = parkingLog.Park(firstCar);
            Assert.Same(firstCar, parkingLog.Pick(carId));
            Assert.Null(parkingLog.Pick(carId));
        }

        [Fact]
        public void should_fail_to_pick_the_not_parked_car()
        {
            var parkingLog = new ParkingLog(1);
            var firstCar = new Car("1");
            var secondCar = new Car("2");
            string carId = parkingLog.Park(firstCar);
            Assert.Same(firstCar, parkingLog.Pick(carId));
            Assert.Null(parkingLog.Pick(secondCar.carId));
        }

        [Fact]
        public void should_pick_two_car_successfully_when_park_two_car()
        {
            var parkingLog = new ParkingLog(12);
            var firstCar = new Car("1");
            var secondCar = new Car("2");
            string firstCarId = parkingLog.Park(firstCar);
            string secondCarId = parkingLog.Park(secondCar);
            Assert.Same(firstCar, parkingLog.Pick(firstCarId));
            Assert.Same(secondCar, parkingLog.Pick(secondCarId));
        }
    }
}
