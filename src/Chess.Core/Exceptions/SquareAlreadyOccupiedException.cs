using System;

namespace Chess.Core.Exceptions
{
    public class SquareAlreadyOccupiedException : Exception
    {
        public SquareAlreadyOccupiedException()
        {
            
        }

        public SquareAlreadyOccupiedException(string message)
            : base(message)
        {
            
        }

        public SquareAlreadyOccupiedException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}