using System;
using Chess.Core.Exceptions;

namespace Chess.Core
{
    /// <summary>Stores a value that indicates a coordinate of a chessboard where rows are called Rank and columns File.</summary>
    public class ChessPosition
    {
        /// <summary>Gets a letter that indicates the columns of a chessboard.</summary>
        /// <value>A <see langword="char"/> value; usually between 'a' to 'h'.</value>
        public char File { get; init; }

        /// <summary>Gets a number that indicates the rows of a chessboard.</summary>
        /// <value>An <see langword="int"/> value; usually between 1 to 8.</value>
        public int Rank { get; init; }

        /// <summary>Subtracts 1 from <see cref="Rank"/> to get a number that represents the row in an array.</summary>
        public int Row => Rank - 1;

        /// <summary>Converts the value of <see cref="File"/> into a numberthat represents the column in an array.</summary>
        public int Column => File - 'a';
        
        /// <summary>Initializes a new instance of the <see cref="ChessPosition"/>class.</summary>
        /// <param name="file">A letter between 'a' to 'h'.</param>
        /// <param name="rank">A number between 1 to 8.</param>
        public ChessPosition(char file, int rank)
        {
            File = file;
            Rank = rank;
        }
        
        /// <summary>Initializes a new instance of the <see cref="ChessPosition"/>class.</summary>
        /// <param name="position">A letter between 'a' to 'h' and a number between 1 to 8.</param>
        /// <exception cref="InvalidChessPositionException"/>
        public ChessPosition(string position)
        {
            _ = position ?? throw new ArgumentNullException(nameof(position), "Cannot pass null to position.");

            if (!IsValidPosition(position))
            {
                throw new InvalidChessPositionException("The position entered was not a valid chess position.");
            }

            File = position[0];
            Rank = (int)char.GetNumericValue(position[1]);
        }

        private static bool IsValidPosition(string position)
        {
            return position.Length == 2 && char.IsLetter(position[0]) && char.IsNumber(position[1]);
        }

        public override bool Equals(object obj)
        {
            if (obj is ChessPosition position)
            {
                return position.File == File && position.Rank == Rank;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Concat(File, Rank);
        }
    }
}
