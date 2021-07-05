using Chess.Core.Moves;
using System.Collections.ObjectModel;

namespace Chess.Core.Pieces
{
    public interface IChessPiece
    {
        /// <summary>
        /// Gets all the moves that a piece can move to on the board.
        /// </summary>
        /// <returns>A collection with all the legal moves.</returns>
        Collection<ChessMove> GetLegalMoves();

        /// <summary>
        /// Indicates whether a specific move is legal.
        /// </summary>
        /// <param name="move">The move to be evaluated.</param>
        /// <returns><see langword="true"/> if it is a legal move; otherwise, <see langword="false"/>.</returns>
        bool IsLegalMove(ChessMove move);
    }
}