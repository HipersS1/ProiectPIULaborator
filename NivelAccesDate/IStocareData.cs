using System;
using System.Collections;
using System.Collections.Generic;
using CarClass;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddCar(Car car);
        void RewriteCars(List<Car> listOfCars);
        ArrayList GetCars();
    }
}
