using Chess.Core.Pieces;

namespace Chess.Core.Board
{
    /// <summary>
    /// Represents a single square of a chessboard.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Gets the row where the square is.
        /// </summary>
        public int Row { get; init; }

        /// <summary>
        /// Gets the column where the square is.
        /// </summary>
        public int Column { get; init; }

        /// <summary>
        /// Gets or Sets the square's piece.
        /// </summary>
        public ChessPiece Piece { get; set; }

        /// <summary>
        /// Gets a value indicating whether the piece is null.
        /// </summary>
        /// <value><see langword="true"/> if the <see cref="Piece"/> is null; otherwise, <see langword="false"/>.</value>
        public bool IsFree => Piece == null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/>class.
        /// </summary>
        /// <param name="row">The row where the square is on the chessboard.</param>
        /// <param name="column">The column where the square is on the chessboard.</param>
        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/>class.
        /// </summary>
        /// <param name="row">The row where the square is on the chessboard.</param>
        /// <param name="column">The column where the square is on the chessboard.</param>
        /// <param name="piece">The square's piece.</param>
        public Square(int row, int column, ChessPiece piece)
            : this(row, column)
        {
            Piece = piece;
        }
    }
}