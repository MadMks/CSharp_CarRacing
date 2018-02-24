using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Дизайн консоли, и вывода текста.
    /// </summary>
    class Design
    {

        /// <summary>
        /// Линия.
        /// </summary>
        /// <param name="symbol">Символ линии.</param>
        public static void Line(char symbol)
        {
            Console.WriteLine(new string(symbol, 36));
        }


        /// <summary>
        /// Цвет текста в консоли по умолчанию.
        /// </summary>
        public static void Default()
        {
            Console.ResetColor();
        }


        /// <summary>
        /// Зеленый цвет текста.
        /// </summary>
        public static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }


        /// <summary>
        /// Красный цвет текста.
        /// </summary>
        public static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }


        /// <summary>
        /// Синий цвет текста.
        /// </summary>
        public static void Blue()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }


    }
}