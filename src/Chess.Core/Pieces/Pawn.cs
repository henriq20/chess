using Chess.Core.Board;
using Chess.Core.Moves;
using System.Collections.ObjectModel;

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

        public override Collection<ChessMove> GetLegalMoves()
        {
            var legalMoves = new Collection<ChessMove>();

            int row = Position.Row;
            int column = Position.Column;

            if (Color == PieceColor.White)
            {
                Square oneSquareAhead = Board[row + 1, column];
                Square twoSquaresAhead = Board[row + 2, column];
                Square diagonalLeft = Board[row + 1, column - 1];
                Square diagonalRight = Board[row + 1, column + 1];

                if (oneSquareAhead != null && oneSquareAhead.IsFree)
                {
                    legalMoves.Add(new ChessMove(Position, oneSquareAhead.Name, ChessMoveType.QuietMove));

                    if (Moves == 0 && twoSquaresAhead != null && twoSquaresAhead.IsFree)
                    {
                        legalMoves.Add(new ChessMove(Position, twoSquaresAhead.Name, ChessMoveType.QuietMove));
                    }
                }
                if (diagonalLeft != null && !diagonalLeft.IsFree && diagonalLeft.Piece.Color != Color)
                {
                    legalMoves.Add(new ChessMove(Position, diagonalLeft.Name, ChessMoveType.Capture));
                }
                if (diagonalRight != null && !diagonalRight.IsFree && diagonalRight.Piece.Color != Color)
                {
                    legalMoves.Add(new ChessMove(Position, diagonalRight.Name, ChessMoveType.Capture));
                }

                return legalMoves;
            }
            else
            {
                Square oneSquareAhead = Board[row - 1, column];
                Square twoSquaresAhead = Board[row - 2, column];
                Square diagonalLeft = Board[row - 1, column + 1];
                Square diagonalRight = Board[row - 1, column - 1];

                if (oneSquareAhead != null && oneSquareAhead.IsFree)
                {
                    legalMoves.Add(new ChessMove(Position, oneSquareAhead.Name, ChessMoveType.QuietMove));

                    if (Moves == 0 && twoSquaresAhead != null && twoSquaresAhead.IsFree)
                    {
                        legalMoves.Add(new ChessMove(Position, twoSquaresAhead.Name, ChessMoveType.QuietMove));
                    }
                }
                if (diagonalLeft != null && !diagonalLeft.IsFree && diagonalLeft.Piece.Color != Color)
                {
                    legalMoves.Add(new ChessMove(Position, diagonalLeft.Name, ChessMoveType.Capture));
                }
                if (diagonalRight != null && !diagonalRight.IsFree && diagonalRight.Piece.Color != Color)
                {
                    legalMoves.Add(new ChessMove(Position, diagonalRight.Name, ChessMoveType.Capture));
                }

                return legalMoves;
            }
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "p" : "P";
        }
    }
}