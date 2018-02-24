using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Список авто пуст. Гонка не может начаться без авто.
    /// </summary>
    [Serializable]
    public class CarListIsEmptyException : Exception
    {
        public CarListIsEmptyException() 
            : this("Список авто пуст. Гонка не может начаться без авто.") { }
        public CarListIsEmptyException(string message) 
            : base(message) { }
        public CarListIsEmptyException(string message, Exception inner) 
            : base(message, inner) { }
        protected CarListIsEmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) { }
    }
}