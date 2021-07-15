using Chess.Core.Board;
using Chess.Core.Pieces;

namespace Chess.Core.Moves
{
    public class ChessMovementRuleOptions
    {
        public ChessMovementRule Rule { get; init; }
         
        public ChessMovementRuleOptions(ChessMovementRule rule)
        {
            Rule = rule;   
        }

        /// <summary>Indicates a condition where the <see cref="Target"/> must be free.</summary>
        /// <returns><see langword="true"/> if it is free; otherwise, <see langword="false"/>.</returns>
        public bool BeFree()
        {
            return TargetNotNull() && Rule.Target.IsFree;
        }

        /// <summary>Indicates a condition where the piece on the <see cref="Target"/> must be an opponent.</summary>
        /// <returns><see langword="true"/> if it is an opponent; otherwise, <see langword="false"/>.</returns>
        public bool BeOpponent()
        {
            return TargetNotNull() && !Rule.Target.IsFree && Rule.Target.Piece.Color != Rule.Piece.Color;
        }

        /// <summary>Indicates a condition where the Piece is a Pawn and can move two squares ahead.</summary>
        /// <returns><see langword="true"/> if it can move; otherwise, <see langword="false"/>.</returns>
        public bool BePush()
        {
            return Rule.Piece is Pawn && Rule.Target.IsFree && Rule.Target.Name.Rank < 8 && Rule.Target.Name.Rank > 1;
        }

        /// <summary>Indicates a condition where the Piece is a Pawn and can move two squares ahead.</summary>
        /// <returns><see langword="true"/> if it can move; otherwise, <see langword="false"/>.</returns>
        public bool BeDoublePush()
        {
            Square neighbour = Rule.Piece.Color == PieceColor.White ? Neighbour(1, 0) : Neighbour(-1, 0);

            return Rule.Piece is Pawn && TargetNotNull() && !HaveMoved() && BeFree() && neighbour.IsFree;
        }

        /// <summary>Indicates a condition where the piece on the <see cref="Target"/> have already moved.</summary>
        /// <returns><see langword="true"/> if it has moved; otherwise, <see langword="false"/>.</returns>
        public bool HaveMoved()
        {
            return Rule.Piece.Moves > 0;
        }

        /// <summary>Indicates a condition where a pawn reaches the last rank and can be promoted to another piece.</summary>
        /// <returns><see langword="true"/> if it can promote; otherwise, <see langword="false"/>.</returns>
        public bool BePromotion()
        {
            if (Rule.Origin.Piece is Pawn && Rule.Origin.Piece.Color == PieceColor.White)
            {
                return Rule.Target.Name.Rank == 8 && Rule.Target.IsFree
                       && Rule.Target.Name.File == Rule.Origin.Piece.Position.File;
            }

            if (Rule.Origin.Piece is Pawn && Rule.Origin.Piece.Color == PieceColor.Black)
            {
                return Rule.Target.Name.Rank == 1 && Rule.Target.IsFree
                       && Rule.Target.Name.File == Rule.Origin.Piece.Position.File;
            }

            return false;
        }

        /// <summary>Gets a square based on the position of the <see cref="Piece"/>.</summary>
        /// <param name="row">The row based on the current row of the <see cref="Piece"/>.</param>
        /// <param name="column">The column based on the current column of the <see cref="Piece"/>.</param>
        /// <returns>The square if found; otherwise, <see langword="null"/>.</returns>
        public Square Neighbour(int row, int column)
        {
            return Rule.Piece.Board[row + Rule.Piece.Position.Row,
                                    column + Rule.Piece.Position.Column];
        }

        private bool TargetNotNull()
        {
            return Rule.Target != null;
        }
    }
}