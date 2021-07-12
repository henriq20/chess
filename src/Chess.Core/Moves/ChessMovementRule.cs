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
        public Collection<Func<ChessMovementRule, bool>> Conditions { get; private set; }

        public ChessMovementRule(ChessPiece piece)
        {
            _ = piece ?? throw new ArgumentNullException(nameof(piece), "Cannot pass null to piece.");
            
            Piece = piece;
            Origin = piece.Board[piece.Position.ToString()];
            Conditions = new Collection<Func<ChessMovementRule, bool>>();
        }

        /// <summary>Sets the <see cref="Target"/> property.</summary>
        /// <param name="row">The row based on the current row of the <see cref="Piece"/>.</param>
        /// <param name="column">The column based on the current column of the <see cref="Piece"/>.</param>
        /// <returns>The same instance, but with the target set.</returns>
        public ChessMovementRule SquareAt(int row, int column)
        {
            Target = Neighbour(row, column);
            return this;
        }

        /// <summary>Defines a condition that the <see cref="Target"/> must meet for it to be a valid move.</summary>
        /// <param name="condition">The condition to be satisfied.</param>
        /// <returns>The same instance, but with the condition added to the <see cref="Conditions"/>.</returns>
        public ChessMovementRule Must(Func<ChessMovementRule, bool> condition)
        {
            Conditions.Add(condition);
            return this;
        }

        /// <summary>Indicates a condition where the piece on the <see cref="Target"/> must be an opponent.</summary>
        /// <returns><see langword="true"/> if it is an opponent; otherwise, <see langword="false"/>.</returns>
        public bool BeOpponent()
        {
            return Target != null && !Target.IsFree && Target.Piece.Color != Piece.Color;
        }

        /// <summary>Indicates a condition where the <see cref="Target"/> must be free.</summary>
        /// <returns><see langword="true"/> if it is free; otherwise, <see langword="false"/>.</returns>
        public bool BeFree()
        {
            return Target != null && Target.IsFree;
        }

        /// <summary>Indicates a condition where the piece on the <see cref="Target"/> have already moved.</summary>
        /// <returns><see langword="true"/> if it has moved; otherwise, <see langword="false"/>.</returns>
        public bool HaveMoved()
        {
            return Piece.Moves > 0;
        }

        /// <summary>Gets a square based on the position of the <see cref="Piece"/>.</summary>
        /// <param name="row">The row based on the current row of the <see cref="Piece"/>.</param>
        /// <param name="column">The column based on the current column of the <see cref="Piece"/>.</param>
        /// <returns>The square if found; otherwise, <see langword="null"/>.</returns>
        public Square Neighbour(int row, int column)
        {
            return Piece.Board[Math.Abs(row + Piece.Position.Row),
                               Math.Abs(column + Piece.Position.Column)];
        }
    }
}