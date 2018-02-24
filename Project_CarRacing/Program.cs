using System;
using static System.Console;
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
            Title = "Автомобильные гонки";

            try
            {
                Game game = new Game(55);

                List<Car> cars = new List<Car>
                {
                    new PassengerCar(4),
                    new Bus(3),
                    new SportsCar(5),
                    new Truck(3)
                };



                game.RegisterCarsHandlers(cars);


                game.Start();
            }
            catch (InvalidLengthOfRaceTrackException e)
            {
                PrintException(e.Message);
            }
            catch (CarListIsEmptyException e)
            {
                PrintException(e.Message);
            }
            catch (UnacceptableMaximumSpeedException e)
            {
                PrintException(e.Message);
            }
            catch (Exception e)
            {
                PrintException(e.Message);
            }


            WriteLine("\n");
        }



        /// <summary>
        /// Вывод исключительных ситуаций (отформатированной строкой).
        /// </summary>
        /// <param name="eMessage">Сообщение исключения.</param>
        private static void PrintException(string eMessage)
        {
            Design.Red();
            WriteLine("\n [error] " + eMessage + "\n");
            Design.Default();
        }


    }
}