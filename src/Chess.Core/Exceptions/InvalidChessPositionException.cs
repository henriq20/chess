using System;

namespace Chess.Core.Exceptions
{
    public class InvalidChessPositionException : Exception
    {
        public InvalidChessPositionException()
        {
            
        }

        public InvalidChessPositionException(string message)
            : base(message)
        {
            
        }

        public InvalidChessPositionException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}