using System;
using Chess.Core.Board;
using Chess.Core.Pieces;
using System.Collections.ObjectModel;

namespace Chess.Core.Moves
{
    /// <summary>Provides conditions for a chess move to be performed.</summary>
    public class ChessMovementRule
    {
        public ChessPiece Piece { get; init; }
        public Square Origin { get; private set; }
        public Square Target { get; private set; }
        public Collection<Func<ChessMovementRuleOptions, bool>> Conditions { get; private set; }

        public ChessMovementRule(ChessPiece piece)
        {
            _ = piece ?? throw new ArgumentNullException(nameof(piece), "Cannot pass null to piece.");
            
            Piece = piece;
            Origin = piece.Board[piece.Position.ToString()];
            Conditions = new Collection<Func<ChessMovementRuleOptions, bool>>();
        }

        /// <summary>Sets the <see cref="Target"/> property.</summary>
        /// <param name="row">The row based on the current row of the <see cref="Piece"/>.</param>
        /// <param name="column">The column based on the current column of the <see cref="Piece"/>.</param>
        /// <returns>The same instance, but with the target set.</returns>
        public ChessMovementRule SquareAt(int row, int column)
        {
            Target = new ChessMovementRuleOptions(this).Neighbour(row, column);
            return this;
        }

        /// <summary>Defines a condition that the <see cref="Target"/> must meet for it to be a valid move.</summary>
        /// <param name="condition">The condition to be satisfied.</param>
        /// <returns>The same instance, but with the condition added to the <see cref="Conditions"/>.</returns>
        public ChessMovementRule Must(Func<ChessMovementRuleOptions, bool> condition)
        {
            Conditions.Add(condition);
            return this;
        }
    }
}