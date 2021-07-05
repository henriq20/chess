using System;

namespace Chess.Core.Board
{
    public class ChessBoard : IChessBoard
    {
        /// <summary>
        /// Gets the length of the board.
        /// </summary>
        public const int Length = 8;

        public Square[,] Squares { get; init; }

        /// <summary>
        /// Gets a square of the board by specifing its row and column.
        /// </summary>
        public Square this[int row, int column] => GetSquare(row, column);

        /// <summary>
        /// Gets a square of the board by specifing its name.
        /// <para>
        /// E.g: "a2", "h7".
        /// </para>
        /// </summary>
        public Square this[string name] => GetSquare(name);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPosition"/>class.
        /// </summary>
        public ChessBoard()
        {
            Squares = new Square[Length, Length];
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
            var position = new ChessPosition(name[0], (int)char.GetNumericValue(name[1]));

            return GetSquare(position.GetRow(), position.GetColumn());
        }

        private Square GetSquare(int row, int column)
        {
            try
            {
                return Squares[row, column];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException
                    ("The specified square does not exist.", e);
            }
        }
        
        private void CreateSquares()
        {
            for (int row = 0; row < Length; row++)
            {
                for (int column = 0; column < Length; column++)
                {
                    var name = new ChessPosition((char)(column + 'a'), row + 1);

                    Squares[row, column] = new Square(name);
                }
            }
        }
    }
}