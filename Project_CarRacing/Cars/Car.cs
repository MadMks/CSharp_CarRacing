using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Класс "Авто".
    /// </summary>
    abstract class Car
    {
        /// <summary>
        /// Делегат, финиш авто.
        /// </summary>
        /// <param name="car">Авто которое финишировало.</param>
        public delegate void FinishDel(Car car);

        /// <summary>
        /// Событие "Финиш".
        /// </summary>
        public event FinishDel Finish;

        /// <summary>
        /// Скорость авто.
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Допустимая максимальная скорость.
        /// </summary>
        private const int _permissibleMaximumSpeed = 10;

        /// <summary>
        /// Максимальная скорость.
        /// </summary>
        private int _topSpeed;
        /// <summary>
        /// Максимальная скорость.
        /// </summary>
        /// Указываем при создании авто.
        /// По умолчанию "0"
        /// При запросе TopSpeed запустит исключительную ситуацию.
        public int TopSpeed
        {
            get { return _topSpeed; }
            set
            {
                if (value > 0 && value <= _permissibleMaximumSpeed)
                {
                    _topSpeed = value;
                }
                else
                {
                    throw new UnacceptableMaximumSpeedException();
                }
            }
        }


        /// <summary>
        /// Текущая позиция авто.
        /// </summary>
        private int _position;
        /// <summary>
        /// Текущая позиция авто.
        /// </summary>
        public int Position
        {
            get { return _position; }
            set
            {
                // Если текущая позиция меньше позиции финиша.
                if (value < MapOfDrivingAuto.Count)
                {
                    _position = value;
                }
                // Иначе присваиваем максимальную(финиш).
                // И зпускаем событие "Финиш".
                else
                {
                    Position = MapOfDrivingAuto.Count - 1;

                    Finish?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Карта передвижения авто.
        /// </summary>
        public List<string> MapOfDrivingAuto { get; set; }
        /// <summary>
        /// Иконка авто на карте передвижения.
        /// </summary>
        private const string AutoIcon = ">";
        /// <summary>
        /// Рандомное число (для получения рандомной скорости).
        /// </summary>
        protected static Random rand;



        // Конструкторы.

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Car() : this(0) { }

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="topSpeed">Максимальная скорость.</param>
        public Car(int topSpeed)
        {
            rand = new Random();

            TopSpeed = topSpeed;

            MapOfDrivingAuto = new List<string>();

            Speed = 0;
            _position = 0;
        }



        // Методы.

        /// <summary>
        /// Получение расстояния гонки (для авто).
        /// </summary>
        /// <param name="distance">Расстояние гонки.</param>
        public void SetDistanceRace(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                MapOfDrivingAuto.Add("-");
            }

            MapOfDrivingAuto[0] = "|";  // линия старта.
            MapOfDrivingAuto[MapOfDrivingAuto.Count - 1] = "|"; // линия финиша.
        }


        
        /// <summary>
        /// Показать карту передвижения авто.
        /// </summary>
        public void ShowMapOfDrivingAuto()
        {
            foreach (string item in MapOfDrivingAuto)   // TODO TODO
            {
                Write(item);
            }
            WriteLine("\t" + this);
        }



        /// <summary>
        /// Выйти на старт.
        /// </summary>
        public void GetReady()
        {
            MapOfDrivingAuto[Position] = AutoIcon;
        }



        /// <summary>
        /// Отметить текущую позицию (на карте передвижения).
        /// </summary>
        /// <param name="currentPosition">Текущая позиция.</param>
        public void MarkThePosition(int currentPosition)
        {
            MapOfDrivingAuto[MapOfDrivingAuto.IndexOf(AutoIcon)] = "-";
            MapOfDrivingAuto[currentPosition] = AutoIcon;
        }



        /// <summary>
        /// Ехать.
        /// </summary>
        public virtual void Drive()
        {
            // Авто едет - меняет скорость,
            // получаем его скорость.
            Speed = rand.Next(1, TopSpeed + 1);
            // "Получаем позицию исходя из скорости".
            Position += Speed;

            MarkThePosition(Position);
        }


    }
}