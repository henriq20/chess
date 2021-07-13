using System.Linq;
using Chess.Core.Moves;
using System.Collections.Generic;
using Chess.Core.Pieces;

namespace Chess.Core.Extensions
{
    public static class ChessPieceExtensions
    {
        public static ChessMovementRule RuleForSquareAt(this ChessPiece piece, int row, int column)
        {
            return new ChessMovementRule(piece).SquareAt(row, column);
        }

        /// <summary>
        /// Selects all rules that its condition is satisfied.
        /// </summary>
        /// <param name="rules">The rules to be checked.</param>
        /// <returns>A list with all legal moves.</returns>
        public static IEnumerable<ChessMove> GetLegalMoves(this IEnumerable<ChessMovementRule> rules)
        {
            return rules.Where(AllConditionsSatisfied)
                        .Select(r => new ChessMove(r.Origin, r.Target));
        }

        private static bool AllConditionsSatisfied(ChessMovementRule rule)
        {
            return rule.Conditions.All(c => c(new ChessMovementRuleOptions(rule)) == true);
        }
    }
}