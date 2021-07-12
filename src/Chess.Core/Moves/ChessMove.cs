using Chess.Core.Board;

namespace Chess.Core.Moves
{
    public record ChessMove(Square Origin, Square Target)
    {
        /// <summary>Gets the old square of the piece.</summary>
        public Square Origin { get; init; } = Origin;

        /// <summary>Gets the new square of the piece.</summary>
        public Square Target { get; init; } = Target;
    }
}