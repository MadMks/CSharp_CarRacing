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

        /// <summary>
        /// Делегат, проверка позиции авто.
        /// </summary>
        /// <returns>Авто.</returns>
        //public delegate Car CheckingTheCarPosition();
        /// <summary>
        /// Собитие "Проверить позиции авто."
        /// </summary>
        //public event CheckingTheCarPosition CheckTheCarPositions;


        // TODO возможно метод регистер (который зарегистрирует сразу везде все машины).
        public void RegisterCarsHandlers(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                DeclareADistanceRace += car.SetDistanceRace;

                GoToTheStart += car.GetReady;
                GoToTheStart += car.ShowMapOfDrivingAuto;

                Race += car.Drive;
                Race += car.ShowMapOfDrivingAuto;

                // на все машины подписать "сообщение о победителе" (оно в гейм - одно).
                car.Finish += Finish;

                //CheckTheCarPositions += car.CheckPosition;
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
            GoToTheStart?.Invoke();
            System.Threading.Thread.Sleep(1000);
            //  отсчет - метод

            StartARace();
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
                // clear
                Console.Clear();

                Race?.Invoke();

                //CheckWinner();
                
                ShowWinnerInTheRace();

                // слип 1 секунда
                System.Threading.Thread.Sleep(1000);

                // Дальше консоль чиститься.
            }

            //UnregisterCarsHandlers();

            //ShowWinnerInTheRace();
        }

        private void Finish(Car car)
        {
            ////Console.WriteLine(" WIN");
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
            Console.WriteLine(" Итоговая таблица:\n");

            //foreach (Car car in SummaryTable)
            //{
            //    Console.WriteLine($"{car.}");
            //}

            for (int i = 0; i < SummaryTable.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {SummaryTable[i].GetType().Name}");
            }
        }

        //private void CheckWinner()
        //{
        //    foreach (CheckingTheCarPosition item in CheckTheCarPositions.GetInvocationList())
        //    {
        //        if (item().Position == Distance)
        //        {
        //            Console.WriteLine(" Победитель: " + item().GetType().Name);
        //            Console.ReadKey();
        //            // TODO остановить гонку - событием.
        //        }
        //    }
        //}


        /// <summary>
        /// Вывод текущего положения автомобилей.
        /// </summary>
        private void ShowCurrentVehiclePosition()
        {
            // TODO write

            // TODO вместо метода событие!!!
        }

        // TODO event победитель ИЛИ метод победитель
        // метод WinnerInTheRace(string ???)
        //private void WinnerInTheRace()
        //{
        //    //foreach (var item in collection)
        //    //{

        //    //}
        //}
    }
}
