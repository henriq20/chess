using Chess.Core.Board;
using Chess.Core.Pieces;
using Chess.Core.Notations;

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
        
        /// <summary>
        /// Builds a string representation of the move.
        /// </summary>
        /// <param name="notationBuilder">The class that will build the notation.</param>
        /// <typeparam name="TBuilder">The type of the class that implements the <see cref="IChessNotationBuilder"/> interface.</typeparam>
        /// <returns>The notation.</returns>
        public string GetNotation<TBuilder>(TBuilder notationBuilder) where TBuilder : IChessNotationBuilder
        {
            return notationBuilder.Build(this);
        }
    }
}