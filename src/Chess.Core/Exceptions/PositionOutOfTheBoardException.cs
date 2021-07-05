using System;

namespace Chess.Core.Exceptions
{
    public class PositionOutOfTheBoardException : Exception
    {
        public PositionOutOfTheBoardException()
        {
            
        }

        public PositionOutOfTheBoardException(string message)
            : base(message)
        {
            
        }

        public PositionOutOfTheBoardException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}