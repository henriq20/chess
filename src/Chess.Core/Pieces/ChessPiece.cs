using Chess.Core.Board;
using Chess.Core.Moves;
using System.Collections.ObjectModel;

namespace Chess.Core.Pieces
{
    public abstract class ChessPiece : IChessPiece
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

        /// <summary>
        /// Gets the board where the piece is.
        /// </summary>
        public IChessBoard Board { get; init; }
        
        protected ChessPiece(PieceColor color, IChessBoard board)
        {
            Color = color;
            Board = board;
        }

        protected ChessPiece(PieceColor color, ChessPosition position, IChessBoard board)
            : this(color, board)
        {
            Position = position;
        }

        /// <summary>
        /// Changes the <see cref="Position"/> and increases the number of <see cref="Moves"/>.
        /// </summary>
        /// <param name="newPosition">The new position of the piece.</param>
        public virtual void ChangePosition(ChessPosition newPosition)
        {
            IncreaseMoves();
            Position = newPosition;
        }

        /// <summary>
        /// Increases the number of moves by 1.
        /// </summary>
        public virtual void IncreaseMoves()
        {
            Moves++;
        }

        /// <summary>
        /// Decreases the number of moves by 1.
        /// </summary>
        public virtual void DecreaseMoves()
        {
            Moves--;
        }

        public virtual bool IsLegalMove(ChessMove move)
        {
            return GetLegalMoves()?.Contains(move) ?? false;
        }
        
        public abstract Collection<ChessMove> GetLegalMoves();
    }
}