﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Класс "Легковое авто".
    /// </summary>
    class PassengerCar : Car
    {
        /// <summary>
        /// Максимальная скорость "PassengerCar" по умолчанию.
        /// </summary>
        private const int _defaultTopSpeed = 4;

        // Конструкторы.

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public PassengerCar() : base(_defaultTopSpeed) { }

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="topSpeed">Максимальная скорость.</param>
        public PassengerCar(int topSpeed) : base(topSpeed) { }




        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}