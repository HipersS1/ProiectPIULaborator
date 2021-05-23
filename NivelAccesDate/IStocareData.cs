using System;
using System.Collections;
using System.Collections.Generic;
using CarClass;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddCar(Car car);//Adauga o masina noua
        void RewriteCars(List<Car> listOfCars);//Rescrie fisierul cu informatiile din lista
        ArrayList GetCars();//Preia informatiile din fisier intr-un arraylist
        List<Car> GetCarsFile();//Preia informatiile din fisier intr-o lista generica
        List<Car> SearchCars(Car autoCautat, List<Car> listaAutoturisme);//Metoda pentru cautarea masinilor care au marca si modelul precizat
        List<Car> ModifyCarPrice(List<Car> listaAutoturisme, Car carToBeModified);
    }
}
