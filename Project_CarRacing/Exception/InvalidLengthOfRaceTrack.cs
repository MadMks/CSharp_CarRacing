using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CarRacing
{
    /// <summary>
    /// Недопустимая длина гоночной трассы.
    /// </summary>
    [Serializable]
    public class InvalidLengthOfRaceTrackException : Exception
    {
        public InvalidLengthOfRaceTrackException() 
            : this("Недопустимая длина гоночной трассы." 
                  + " Допустимая от 5 до 55.") { }
        public InvalidLengthOfRaceTrackException(string message) 
            : base(message) { }
        public InvalidLengthOfRaceTrackException(string message, Exception inner) 
            : base(message, inner) { }
        protected InvalidLengthOfRaceTrackException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) { }
    }
}