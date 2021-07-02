namespace Chess.Core.Pieces
{
    public abstract class ChessPiece
    {
        /// <summary>
        /// Gets the number of times the piece has moved.
        /// </summary>
        public int Moves { get; private set; }

        /// <summary>
        /// Gets the color of the piece.
        /// </summary>
        public PieceColor Color { get; init; }

        /// <summary>
        /// Gets the position of the piece on the board.
        /// </summary>
        public ChessPosition Position { get; private set; }
        
        protected ChessPiece(PieceColor color, ChessPosition position)
        {
            Color = color;
            Position = position;
        }
        
        /// <summary>
        /// Updates the <see cref="Position"/> and increases the number of <see cref="Moves"/>.
        /// </summary>
        /// <param name="newPosition">The new position of the piece.</param>
        public virtual void UpdatePosition(ChessPosition newPosition)
        {
            Moves++;
            Position = newPosition;
        }
    }
}