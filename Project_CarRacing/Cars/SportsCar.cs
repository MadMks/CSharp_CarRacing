using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Класс "Спорткар".
    /// </summary>
    class SportsCar : Car
    {
        /// <summary>
        /// Максимальная скорость "SportsCar" по умолчанию.
        /// </summary>
        private const int _defaultTopSpeed = 5;

        // Конструкторы.

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public SportsCar() : base(_defaultTopSpeed) { }

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="topSpeed">Максимальная скорость.</param>
        public SportsCar(int topSpeed) : base(topSpeed) { }




        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}