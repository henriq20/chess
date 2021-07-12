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
                new ChessMovementRule(this).SquareAt( 1,  0).Must(BeFreeOrOpponent), // One square ahead
                new ChessMovementRule(this).SquareAt( 1, -1).Must(BeFreeOrOpponent), // One square ahead on the left
                new ChessMovementRule(this).SquareAt( 1,  1).Must(BeFreeOrOpponent), // One square ahead on the right
                new ChessMovementRule(this).SquareAt( 0, -1).Must(BeFreeOrOpponent), // One square on the left
                new ChessMovementRule(this).SquareAt( 0,  1).Must(BeFreeOrOpponent), // One square on the right
                new ChessMovementRule(this).SquareAt(-1,  0).Must(BeFreeOrOpponent), // One square back
                new ChessMovementRule(this).SquareAt(-1, -1).Must(BeFreeOrOpponent), // One square back on the left
                new ChessMovementRule(this).SquareAt(-1,  1).Must(BeFreeOrOpponent), // One square back on the right
            };

            return rules.GetLegalMoves();
        }

        private static bool BeFreeOrOpponent(ChessMovementRule rule)
        {
            return rule.BeFree() || rule.BeOpponent();
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "k" : "K";
        }
    }
}