using Chess.Core.Board;
using Chess.Core.Moves;
using Chess.Core.Extensions;
using System.Collections.Generic;

namespace Chess.Core.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor color, IChessBoard board)
            : base(color, board)
        {

        }
        
        public Pawn(PieceColor color, ChessPosition position, IChessBoard board)
            : base(color, position, board)
        {

        }

        public override IEnumerable<ChessMove> GetLegalMoves()
        {
            List<ChessMovementRule> rules;

            if (Color == PieceColor.White)
            {
                rules = new List<ChessMovementRule>()
                {
                    this.RuleForSquareAt(1,  0).Must(o => o.BeFree()), // One square ahead
                    this.RuleForSquareAt(2,  0).Must(o => o.BeDoublePush()), // Two squares ahead
                    this.RuleForSquareAt(1, -1).Must(o => o.BeOpponent()), // One square ahead on the left
                    this.RuleForSquareAt(1,  1).Must(o => o.BeOpponent()), // One square ahead on the right
                };

                return rules.GetLegalMoves();
            }

            rules = new List<ChessMovementRule>()
            {
                this.RuleForSquareAt(-1,  0).Must(o => o.BeFree()), // One square ahead
                this.RuleForSquareAt(-2,  0).Must(o => o.BeDoublePush()), // Two squares ahead
                this.RuleForSquareAt(-1, -1).Must(o => o.BeOpponent()), // One square ahead on the left
                this.RuleForSquareAt(-1,  1).Must(o => o.BeOpponent()) // One square ahead on the right
            };

            return rules.GetLegalMoves();
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "p" : "P";
        }
    }
}