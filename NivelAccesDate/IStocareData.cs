using System;
using System.Collections;
using CarClass;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddCar(Car car);
        ArrayList GetCars();
    }
}
