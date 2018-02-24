using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Класс "Игра".
    /// </summary>
    class Game
    {
        /// <summary>
        /// Время обновления экрана в миллисекундах.
        /// </summary>
        private const int _updateScreenTimeMS = 500;

        /// <summary>
        /// Кол-во авто участвующих в гонке.
        /// </summary>
        private int _numberCarInRace;
        /// <summary>
        /// Кол-во авто участвующих в гонке.
        /// </summary>
        public int NumberCarInRace
        {
            get { return _numberCarInRace; }
            set
            {
                if (value > 0)
                {
                    _numberCarInRace = value;
                }
                else
                {
                    throw new CarListIsEmptyException();
                }
            }
        }


        /// <summary>
        /// Итоговая таблица (победителей).
        /// </summary>
        private List<Car> SummaryTable { get; set; }


        /// <summary>
        /// Минимальная длина гоночной трассы.
        /// </summary>
        private const int _minDistance = 5;
        /// <summary>
        /// Максимальная длина гоночной трассы.
        /// </summary>
        private const int _mахDistance = 55;

        /// <summary>
        /// Дистанция гонки.
        /// </summary>
        private int _distance;
        /// <summary>
        /// Дистанция гонки.
        /// </summary>
        public int Distance
        {
            get { return _distance; }
            set
            {
                if (value >= _minDistance && value <= _mахDistance)
                {
                    _distance = value;
                }
                else
                {
                    throw new InvalidLengthOfRaceTrackException();
                }
            }
        }


        // Делегаты.

        /// <summary>
        /// Делегат, методы игры.
        /// </summary>
        public delegate void GameDelegate();
        /// <summary>
        /// Делегат, передача дистанции игрокам(авто).
        /// </summary>
        /// <param name="distance">Дистанция гонки.</param>
        public delegate void DistanceDelegate(int distance);


        // События.
        
        /// <summary>
        /// Событие "Сообщить о дистанции гонки".
        /// </summary>
        private event DistanceDelegate DeclareADistanceRace;
        /// <summary>
        /// Событие "Показать карту передвижения всех машин".
        /// </summary>
        private event GameDelegate ShowMapAllCar;
        /// <summary>
        /// Событие "Выйти на старт".
        /// </summary>
        private event GameDelegate GoToTheStart;
        /// <summary>
        /// Событие "Гонка".
        /// </summary>
        private event GameDelegate Race;


        // Конструкторы.

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Game() : this(5) { }
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="distance">Дистанция гонки.</param>
        public Game(int distance)
        {
            Distance = distance;

            SummaryTable = new List<Car>();
        }



        // Методы.

        /// <summary>
        /// Регистрируем все авто в гонке.
        /// </summary>
        /// <param name="cars">Список авто.</param>
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

                car.Finish += Finish;
            }

            NumberCarInRace = cars.Count;

            TellTheDistancePlayers(Distance);
        }

        

        /// <summary>
        /// Останавливаем авто.
        /// </summary>
        private void StopTheCar(Car car)
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
        /// Старт игры.
        /// </summary>
        public void Start()
        {
            ShowHeader("Гоночная трасса пуста.");

            ShowMapAllCar?.Invoke();

            WriteLine("\n Нажмите любую клавишу для начала гонок...");
            ReadKey();

            GoToTheStart?.Invoke();

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
                Clear();

                ShowHeader("Обратный отсчет: " + i);

                ShowMapAllCar?.Invoke();

                System.Threading.Thread.Sleep(1000);

                // NOTE: дальше консоль чиститься. 
            }
        }

        

        /// <summary>
        /// Начать гонку.
        /// </summary>
        private void StartARace()
        {
            while (SummaryTable.Count != NumberCarInRace)
            {
                Clear();
                ShowHeader("Гонка:");

                Race?.Invoke();
                
                ShowWinnerInTheRace();

                System.Threading.Thread.Sleep(_updateScreenTimeMS);

                // NOTE: дальше консоль чиститься.
            }

            ShowRaceWinner();
        }



        /// <summary>
        /// Показать победителя гонки.
        /// </summary>
        private void ShowRaceWinner()
        {
            WriteLine("\n" + new string('=', 36));
            Design.Green();
            WriteLine("\n Первое место занял: " 
                + SummaryTable[0].GetType().Name);
            Design.Default();
        }



        /// <summary>
        /// Финиш для авто.
        /// </summary>
        /// <param name="car">Авто приехавшее на финиш.</param>
        private void Finish(Car car)
        {
            StopTheCar(car);

            RecordInTheWinnersTable(car);
        }



        /// <summary>
        /// Записать авто в список победителей.
        /// </summary>
        /// <param name="car">Авто приехавшее на финиш.</param>
        private void RecordInTheWinnersTable(Car car)
        {
            SummaryTable.Add(car);
        }



        /// <summary>
        /// Показать всех учасников(победителей) приехавших на финиш.
        /// </summary>
        private void ShowWinnerInTheRace()
        {
            if (ThereAreWinners())
            {
                WriteLine("\n Итоговая таблица:");
                Design.Line('-');

                for (int i = 0; i < SummaryTable.Count; i++)
                {
                    WriteLine($" {i + 1}. {SummaryTable[i].GetType().Name}");
                }
            }
        }



        /// <summary>
        /// Есть ли хоть один победитель.
        /// </summary>
        /// <returns>Возвращает "true" если хоть одно авто приехало на финиш.</returns>
        private bool ThereAreWinners()
        {
            return SummaryTable.Count > 0;
        }



        /// <summary>
        /// Вывести хедер с текстом.
        /// </summary>
        /// <param name="str">Выводимая строка.</param>
        private void ShowHeader(string str)
        {
            WriteLine("\n " + str);
            Design.Line('=');
            WriteLine();
        }


    }
}