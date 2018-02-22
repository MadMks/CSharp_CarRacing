using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Класс "Автобус".
    /// </summary>
    class Bus : Car
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Bus() : base(2) { }
        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="topSpeed">максимальная скорость.</param>
        public Bus(int topSpeed) : base(topSpeed) { }



        /// <summary>
        /// Ехать.
        /// </summary>
        public override void Drive()
        {
            // Авто едет - меняет скорость,
            // получаем его скорость.
            Speed = rand.Next(1, TopSpeed + 1);
            //Speed = 1;
            ////Console.WriteLine($" ) speed = {Speed}");    // TODO delete
            // По скорости "вычисляем" текущую позицию.
            Position += Speed;
            ////Console.WriteLine(" " + Position);
            //CalculateTheCurrentPosition();
            MarkThePosition(Position);
        }



        public override string ToString()
        {
            return this.GetType().Name;
        }

    }
}
