using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Неприемлемая максимальная скорость.
    /// </summary>
    [Serializable]
    public class UnacceptableMaximumSpeedException : Exception
    {
        public UnacceptableMaximumSpeedException() 
            : this ("Неприемлемая максимальная скорость." 
                  + " Допустимая от 1 до 10.") { }
        public UnacceptableMaximumSpeedException(string message) 
            : base(message) { }
        public UnacceptableMaximumSpeedException(string message, Exception inner) 
            : base(message, inner) { }
        protected UnacceptableMaximumSpeedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) { }
    }
}