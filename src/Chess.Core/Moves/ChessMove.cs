namespace Chess.Core.Moves
{
    public record ChessMove(ChessPosition From, ChessPosition To, ChessMoveType Type)
    {
        /// <summary>Gets the old position of the piece.</summary>
        public ChessPosition From { get; init; } = From;

        /// <summary>Gets the new position of the piece.</summary>
        public ChessPosition To { get; init; } = To;
        
        /// <summary>Gets the type of the move.</summary>
        public ChessMoveType Type { get; init; } = Type;
    }
}