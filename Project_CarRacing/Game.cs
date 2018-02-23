using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Класс "Игра".
    /// </summary>
    class Game  // TODO static all
    {
        public int NumberCarInRace { get; set; }

        /// <summary>
        /// Итоговая таблица (победителей).
        /// </summary>
        public List<Car> SummaryTable { get; set; }


        // TODO min and max distance
        /// <summary>
        /// Дистанция гонки.
        /// </summary>
        public int Distance { get; set; }   // TODO не меньше 5 и не больше ?

        public Game() : this(5){ }
        public Game(int distance)
        {
            Distance = distance;

            SummaryTable = new List<Car>();
        }


        /// <summary>
        /// Делегат, методы игры.
        /// </summary>
        public delegate void GameDelegate();

        public delegate void DistanceDelegate(int distance);
        /// <summary>
        /// Событие "Сообщить о дистанции гонки".
        /// </summary>
        public event DistanceDelegate DeclareADistanceRace;

        public event GameDelegate ShowMapAllCar;


        // TODO возможно метод регистер (который зарегистрирует сразу везде все машины).
        public void RegisterCarsHandlers(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                DeclareADistanceRace += car.SetDistanceRace;

                ShowMapAllCar += car.ShowMapOfDrivingAuto;

                GoToTheStart += car.GetReady;
                GoToTheStart += car.ShowMapOfDrivingAuto;

                Race += car.Drive;
                Race += car.ShowMapOfDrivingAuto;

                // на все машины подписать "сообщение о победителе" (оно в гейм - одно).
                car.Finish += Finish;
            }

            NumberCarInRace = cars.Count;

            TellTheDistancePlayers(Distance);
        }

        //public void UnregisterCarsHandlers()
        //{
        //    foreach (Car car in SummaryTable)
        //    {
        //        Race -= car.ShowMapOfDrivingAuto;
        //    }
        //}

        /// <summary>
        /// Останавливаем авто.
        /// </summary>
        public void StopTheCar(Car car)
        {
            Race -= car.Drive;
        }


        /// <summary>
        /// Объявляем данные о дистанции гонки игрокам.
        /// </summary>
        /// <param name="distance">Дистанция гонки.</param>
        private void TellTheDistancePlayers(int distance)
        {
            DeclareADistanceRace?.Invoke(distance);
        }



        /// <summary>
        /// Событие "Выйти на старт".
        /// </summary>
        public event GameDelegate GoToTheStart;
        /// <summary>
        /// Старт игры.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("\n Гоночная трасса пуста.");
            Console.WriteLine(new string('=', 36));
            /*
            ShowHeader("Гоночная трасса пуста.");
            */

            ShowMapAllCar?.Invoke();

            Console.WriteLine("\n Нажмите любую клавишу для начала гонок...");
            Console.ReadKey();

            GoToTheStart?.Invoke();
            //System.Threading.Thread.Sleep(1000);

            Countdown();

            StartARace();
        }



        /// <summary>
        /// Обратный отсчет (начинается с "5").
        /// </summary>
        private void Countdown()
        {
            for (int i = 5; i >= 0; i--)
            {
                Console.Clear();

                Console.WriteLine($"\n Т-: {i}");
                Console.WriteLine(new string('=', 36));
                /*
                ShowHeader("Обратный отсчет: " + i);
                */

                ShowMapAllCar?.Invoke();

                System.Threading.Thread.Sleep(1000);
                // NOTE: дальше консоль чиститься. 
            }
        }

        // TODO event StartARace    (начать гонку)
        /// <summary>
        /// Событие "Гонка".
        /// </summary>
        private event GameDelegate Race;
        /// <summary>
        /// Начать гонку.
        /// </summary>
        private void StartARace()
        {
            while (SummaryTable.Count != NumberCarInRace)
            {
                Console.Clear();

                Console.WriteLine($"\n Гонка:");
                Console.WriteLine(new string('=', 36));
                /*
                ShowHeader("Гонка:");
                */

                Race?.Invoke();
                
                ShowWinnerInTheRace();

                System.Threading.Thread.Sleep(1000);    // TODO method Pause(msec)

                // Дальше консоль чиститься.
            }

            ShowRaceWinner();
        }

        private void ShowRaceWinner()
        {
            Console.WriteLine("\n\n Первое место занял: " 
                + SummaryTable[0].GetType().Name);
        }

        private void Finish(Car car)
        {
            StopTheCar(car);

            RecordInTheWinnersTable(car);

            //ShowWinnerInTheRace();  // ???
            //Console.ReadKey();
        }

        private void RecordInTheWinnersTable(Car car)
        {
            SummaryTable.Add(car);
        }

        private void ShowWinnerInTheRace()
        {
            if (SummaryTable.Count > 0)
            {
                Console.WriteLine("\n Итоговая таблица:");
                Console.WriteLine(new string('-', 36));
            }


            for (int i = 0; i < SummaryTable.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {SummaryTable[i].GetType().Name}");
            }
        }
        
        /*
        private void ShowHeader(string str)
        {
        	Console.WriteLine("\n " + str);
            Console.WriteLine(new string('=', 36));
            Console.WriteLine();
        }
        */


    }
}
