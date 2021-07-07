using Chess.Core.Board;

namespace Chess.Core.Moves
{
    public record ChessMove(Square From, Square To, ChessMoveType Type)
    {
        /// <summary>Gets the old square of the piece.</summary>
        public Square From { get; init; } = From;

        /// <summary>Gets the new square of the piece.</summary>
        public Square To { get; init; } = To;
        
        /// <summary>Gets the type of the move.</summary>
        public ChessMoveType Type { get; init; } = Type;
    }
}