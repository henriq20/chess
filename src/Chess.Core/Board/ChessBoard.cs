using System;
using Chess.Core.Exceptions;

namespace Chess.Core.Board
{
    public class ChessBoard : IChessBoard
    {
        private readonly Square[][] squares;

        /// <summary>
        /// Gets the length of the board.
        /// </summary>
        public const int Length = 8;

        public Square this[int row, int column] => GetSquare(row, column);

        public Square this[string name] => GetSquare(name);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPosition"/>class.
        /// </summary>
        public ChessBoard()
        {
            squares = new Square[Length][];
        }

        public void Setup()
        {
            CreateSquares();
        }

        public void Clear()
        {
            for (int row = 0; row < Length; row++)
            {
                for (int column = 0; column < Length; column++)
                {
                    this[row, column].TakeOut();
                }
            }
        }

        private Square GetSquare(string name)
        {
            _ = name ?? throw new ArgumentNullException(nameof(name), "aa");

            var position = new ChessPosition(name[0], (int)char.GetNumericValue(name[1]));

            return GetSquare(position.GetRow(), position.GetColumn());
        }

        private Square GetSquare(int row, int column)
        {
            try
            {
                return squares[row][column];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new PositionOutOfTheBoardException
                    ("The specified square does not exist on the board.", e);
            }
        }
        
        private void CreateSquares()
        {
            for (int row = 0; row < Length; row++)
            {
                squares[row] = new Square[Length];

                for (int column = 0; column < Length; column++)
                {
                    var name = new ChessPosition((char)(column + 'a'), row + 1);

                    squares[row][column] = new Square(name);
                }
            }
        }
    }
}