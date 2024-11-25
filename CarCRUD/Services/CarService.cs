using CarCRUD.Models;

namespace CarCRUD.Services;
{
public class CarService

{
    private List<Car> cars;
    public CarService()
    {
        cars = new List<Car>();
        DataSeed();
    }

    public Car AddCar(Car car)
    {
        car.ID = Guid.NewGuid();
        cars.Add(car);
        return car;
    }

    public bool DeleteCar(Guid carID)
    {
        var exist = false;
        foreach (var car in cars)
        {
            if (car.Id == carID)
            {
                cars.Remove(car);
                exist = true;
                break;
            }
        }

        return exist;
    }
    public bool UpdateCar(Car updatecar)
    {
        for (var i = 0; i < cars.Count; i++)
        {
            if (cars[i].Id == updatecar.Id)
            {
                cars[i] = updatecar;
                return true;
            }
        }
        return false;
    }

    public Car GetById(Guid carId)
    {
        foreach (var car in cars)
        {
            if (car.Id == carId)
                return car;
        }
        return null;
    }

    public List<Car> GetAllCars()
    {
    return cars;
    }






}


