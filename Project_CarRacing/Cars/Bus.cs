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
        /// Максимальная скорость "Bus" по умолчанию.
        /// </summary>
        private const int _defaultTopSpeed = 2;

        // Конструкторы.

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Bus() : base(_defaultTopSpeed) { }

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="topSpeed">Максимальная скорость.</param>
        public Bus(int topSpeed) : base(topSpeed) { }




        public override string ToString()
        {
            return this.GetType().Name;
        }


    }
}