using System;
using Chess.Core.Moves;
using Chess.Core.Pieces;

namespace Chess.Core.Notations
{
    public class AlgebraicNotationBuilder : IChessNotationBuilder
    {
        private char pieceAbbreviation;
        private string targetSquareName;
        private ChessPiece movingPiece;

        public string Build(ChessMove move)
        {
            _ = move ?? throw new ArgumentNullException(nameof(move), "Cannot pass null to move.");

            movingPiece = move.Origin.Piece;
            targetSquareName = move.Target.Name.ToString();
            pieceAbbreviation = char.ToUpperInvariant(movingPiece.ToString()[0]);

            return move.Type switch
            {
                ChessMoveType.KingsideCastling => "O-O",
                ChessMoveType.QueensideCastling => "O-O-O",
                ChessMoveType.Quiet => BuildNotationForQuietMove(),
                ChessMoveType.Promotion => BuildNotationForPromotion(),
                ChessMoveType.Capture or ChessMoveType.EnPassant => BuildNotationForCapture(),
                _ => string.Empty
            };
        }

        private string BuildNotationForQuietMove()
        {
            if (movingPiece is Pawn)
            {
                return targetSquareName;
            }

            return string.Concat(pieceAbbreviation, targetSquareName);
        }

        private string BuildNotationForCapture()
        {
            var notation = string.Concat("x", targetSquareName);
            
            if (movingPiece is Pawn)
            {
                return notation.Insert(0, movingPiece.Position.File.ToString());
            }

            return notation.Insert(0, pieceAbbreviation.ToString());
        }

        private string BuildNotationForPromotion()
        {
            var notation = string.Empty;
            var possiblePiecesForPromotion = new char[4] { 'Q', 'R', 'N', 'B' };

            foreach (var piece in possiblePiecesForPromotion)
            {
                notation += string.Concat(targetSquareName, "=", piece, ", ");
            }

            // Removes the ", " after the last piece letter
            return notation.Remove(notation.Length - 2, 2);
        }
    }
}