using System;
using Chess.Core.Pieces;
using Chess.Core.Exceptions;

namespace Chess.Core.Board
{
    /// <summary>
    /// Represents a single square of a chessboard.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Gets an identifier of the square that is represented by a letter followed by a number. 
        /// </summary>
        public ChessPosition Name { get; init; }

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
        /// <param name="name">The square's identifier.</param>
        public Square(ChessPosition name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/>class.
        /// </summary>
        /// <param name="name">The square's identifier.</param>
        /// <param name="piece">The square's piece.</param>
        public Square(ChessPosition name, ChessPiece piece)
            : this(name)
        {
            Piece = piece;
        }

        /// <summary>
        /// Places a piece on the square.
        /// <para>
        /// The position of the piece will be changed if its position does not equal to the square.
        /// </para>
        /// </summary>
        /// <param name="piece">The piece to place on the square.</param>
        /// <exception cref="SquareAlreadyOccupiedException"/>
        public void Place(ChessPiece piece)
        {
            _ = piece ?? throw new ArgumentNullException(nameof(piece), "Cannot place a piece that is null");

            if (!IsFree)
            {
                throw new SquareAlreadyOccupiedException
                    ("The square is already occupied. Take out the piece before placing another one.");
            }
            if (!Name.Equals(piece.Position))
            {
                piece.ChangePosition(Name);
                piece.DecreaseMoves();
            }
            
            Piece = piece;
        }

        /// <summary>
        /// Takes the <see cref="Piece"/> out from the square.
        /// </summary>
        /// <returns>The taken piece if it exists; otherwise, <see langword="null"/>.</returns>
        public ChessPiece TakeOut()
        {
            if (!IsFree)
            {
                var piece = Piece;
                Piece = null;

                return piece;
            }

            return null;
        }
    }
}