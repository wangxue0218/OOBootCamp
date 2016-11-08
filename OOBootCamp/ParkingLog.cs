using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp
{
    public class ParkingLog
    {
        public int number;
        IList<Car> carList = new List<Car>(); 

        public ParkingLog()
        {
        }

        public ParkingLog(int number)
        {
            this.number = number;
        }

        public string Park(Car car)
        {
            if (number>0)
            {
                carList.Add(car);
                number --;
                return car.carId;
            }
            return "The Parking Lot is full, can't park any more!";
        }

        public Car Pick(string carId)
        {
            Car pickCar = carList.Where(c => c.carId.Equals(carId)).SingleOrDefault();
            carList.Remove(pickCar);
            number ++;
            return pickCar;
        }
    }
}
