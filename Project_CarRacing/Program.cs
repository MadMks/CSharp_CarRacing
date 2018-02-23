using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    class Program
    {
        static void Main(string[] args)
        {

            //Bus b = new Bus();
            //b.ShowMapOfDrivingAuto();
            //b.GetReady();
            //b.ShowMapOfDrivingAuto();
            //b.Drive();
            //b.ShowMapOfDrivingAuto();
            //b.Drive();
            //b.ShowMapOfDrivingAuto();

            Game game = new Game(25);

            List<Car> cars = new List<Car>
            {
                new Bus(2),
                new Bus(3)
            };
            //Bus bus = new Bus(2);
            

            game.RegisterCarsHandlers(cars);

            //foreach (Car item in cars)
            //{
            //    item.ShowMapOfDrivingAuto();
            //}
            //Console.ReadKey();
            //Console.Clear();

            game.Start();


            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
