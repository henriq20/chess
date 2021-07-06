using System;

namespace Chess.Core.Board
{
    public class ChessBoard : IChessBoard
    {
        private readonly Square[][] squares;

        public int Length { get; init; }
        
        public Square this[int row, int column] => GetSquare(row, column);

        public Square this[string name] => GetSquare(name);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoard"/>class
        /// and a jagged array with 64 squares.
        /// </summary>
        public ChessBoard()
        {
            Length = 8;
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

            return GetSquare(position.Row, position.Column);
        }

        private Square GetSquare(int row, int column)
        {
            try
            {
                return squares[row][column];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
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