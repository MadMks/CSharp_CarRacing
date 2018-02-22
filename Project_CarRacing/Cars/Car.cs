using System;
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
        public delegate void FinishDel(Car car);
        public event FinishDel Finish;

        /// <summary>
        /// Скорость авто.
        /// </summary>
        public int Speed { get; set; }
        

        /// <summary>
        /// Максимальная скорость.
        /// </summary>
        private int _topSpeed;
        /// <summary>
        /// Максимальная скорость.
        /// </summary>
        public int TopSpeed
        {
            get
            {
                if (_topSpeed != 0)
                {
                    return _topSpeed;
                }
                Console.WriteLine("Макс скорость не может быть 0");
                throw new Exception();  // TODO throw Макс скорость не может быть 0
            }
        }


        /// <summary>
        /// Текущая позиция авто.
        /// </summary>
        //public int Position { get; set; }
        private int _position;

        public int Position
        {
            get { return _position; }
            set
            {
                if (value < MapOfDrivingAuto.Count)
                {
                    _position = value;
                }
                else
                {
                    Position = MapOfDrivingAuto.Count - 1;
                    Finish?.Invoke(this);
                    //Position = MapOfDrivingAuto.Count - 1;
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



        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Car() : this(0)
        {
            Speed = 0;
            Position = 0;

            
        }



        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="topSpeed">Максимальная скорость.</param>
        public Car(int topSpeed)
        {
            rand = new Random();

            _topSpeed = topSpeed;

            //MapOfDrivingAuto = new List<string>(5);
            MapOfDrivingAuto = new List<string>();    // TODO new future

            //for (int i = 0; i < MapOfDrivingAuto.Capacity; i++)
            //{
            //    MapOfDrivingAuto.Add("-");
            //}

            //MapOfDrivingAuto[0] = "|";
            //MapOfDrivingAuto[MapOfDrivingAuto.Count - 1] = "|";
        }


        // метод получение расстояния гонки
        public void SetDistanceRace(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                MapOfDrivingAuto.Add("-");
            }

            MapOfDrivingAuto[0] = "|";
            MapOfDrivingAuto[MapOfDrivingAuto.Count - 1] = "|";
        }
        
        /// <summary>
        /// Показать карту передвижения авто.
        /// </summary>
        public void ShowMapOfDrivingAuto()
        {
            foreach (string item in MapOfDrivingAuto)
            {
                Console.Write(item);
            }
            Console.WriteLine("\t" + this);
        }



        /// <summary>
        /// Выйти на старт.
        /// </summary>
        public void GetReady()
        {
            if (TopSpeed != 0)  // TODO поставил exc - проверка уже не нужна.
            {
                MapOfDrivingAuto[Position] = AutoIcon;
            }
        }

        // TODO изменить скорость(){SwapPosition(speed)} - !?



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
        /// Вычисление текущей позиции авто.
        /// </summary>
        //protected void CalculateTheCurrentPosition()
        //{
        //    if ((Position + Speed) <= MapOfDrivingAuto.Count)
        //    {
        //        Position += Speed;
        //    }
        //    else
        //    {
        //        Position = MapOfDrivingAuto.Count - 1;
        //    }
        //}



        /// <summary>
        /// Ехать.
        /// </summary>
        public abstract void Drive();

        /// <summary>
        /// Проверка позиции авто.
        /// </summary>
        /// <returns>Авто.</returns>
        //public Car CheckPosition()
        //{
        //    return this;
        //}

        // TODO Стоп
    }
}
