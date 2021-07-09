using Chess.Core.Board;

namespace Chess.Core.Moves
{
    public record ChessMove(Square Origin, Square Target, ChessMoveType Type)
    {
        /// <summary>Gets the old square of the piece.</summary>
        public Square Origin { get; init; } = Origin;

        /// <summary>Gets the new square of the piece.</summary>
        public Square Target { get; init; } = Target;
        
        /// <summary>Gets the type of the move.</summary>
        public ChessMoveType Type { get; init; } = Type;
    }
}