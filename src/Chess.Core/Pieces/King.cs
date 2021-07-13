using Chess.Core.Board;
using Chess.Core.Moves;
using Chess.Core.Extensions;
using System.Collections.Generic;

namespace Chess.Core.Pieces
{
    public class King : ChessPiece
    {
        public King(PieceColor color, IChessBoard board)
            : base(color, board)
        {

        }
        
        public King(PieceColor color, ChessPosition position, IChessBoard board)
            : base(color, position, board)
        {

        }

        public override IEnumerable<ChessMove> GetLegalMoves()
        {
            var rules = new List<ChessMovementRule>()
            {
                this.RuleForSquareAt( 1,  0).Must(BeFreeOrOpponent), // One square ahead
                this.RuleForSquareAt( 1, -1).Must(BeFreeOrOpponent), // One square ahead on the left
                this.RuleForSquareAt( 1,  1).Must(BeFreeOrOpponent), // One square ahead on the right
                this.RuleForSquareAt( 0, -1).Must(BeFreeOrOpponent), // One square on the left
                this.RuleForSquareAt( 0,  1).Must(BeFreeOrOpponent), // One square on the right
                this.RuleForSquareAt(-1,  0).Must(BeFreeOrOpponent), // One square back
                this.RuleForSquareAt(-1, -1).Must(BeFreeOrOpponent), // One square back on the left
                this.RuleForSquareAt(-1,  1).Must(BeFreeOrOpponent), // One square back on the right
            };

            return rules.GetLegalMoves();
        }

        private static bool BeFreeOrOpponent(ChessMovementRuleOptions options)
        {
            return options.BeFree() || options.BeOpponent();
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "k" : "K";
        }
    }
}