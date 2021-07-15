using Chess.Core.Moves;

namespace Chess.Core.Notations
{
    public interface IChessNotationBuilder
    {
        /// <summary>
        /// Builds a string representation of a chess move.
        /// </summary>
        /// <param name="move">The move to build the notation.</param>
        /// <returns>The notation.</returns>
        string Build(ChessMove move);
    }
}