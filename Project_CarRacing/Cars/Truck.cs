using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Класс "Грузовик".
    /// </summary>
    class Truck : Car
    {
        /// <summary>
        /// Максимальная скорость "Truck" по умолчанию.
        /// </summary>
        private const int _defaultTopSpeed = 3;

        // Конструкторы.

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Truck() : base(_defaultTopSpeed) { }

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="topSpeed">Максимальная скорость.</param>
        public Truck(int topSpeed) : base(topSpeed) { }




        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}