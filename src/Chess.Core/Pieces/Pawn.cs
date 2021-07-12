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
                    new ChessMovementRule(this).SquareAt(1,  0).Must(r => r.BeFree()), // One square ahead
                    new ChessMovementRule(this).SquareAt(2,  0).Must(r => r.BeFree() && !r.HaveMoved() && r.Neighbour(1, 0).IsFree), // Two squares ahead
                    new ChessMovementRule(this).SquareAt(1, -1).Must(r => r.BeOpponent()), // One square ahead on the left
                    new ChessMovementRule(this).SquareAt(1,  1).Must(r => r.BeOpponent()), // One square ahead on the right
                };

                return rules.GetLegalMoves();
            }

            rules = new List<ChessMovementRule>()
            {
                new ChessMovementRule(this).SquareAt(-1,  0).Must(r => r.BeFree()), // One square ahead
                new ChessMovementRule(this).SquareAt(-2,  0).Must(r => r.BeFree() && !r.HaveMoved() && r.Neighbour(-1, 0).IsFree), // Two squares ahead
                new ChessMovementRule(this).SquareAt(-1, -1).Must(r => r.BeOpponent()), // One square ahead on the left
                new ChessMovementRule(this).SquareAt(-1,  1).Must(r => r.BeOpponent()) // One square ahead on the right
            };

            return rules.GetLegalMoves();
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "p" : "P";
        }
    }
}