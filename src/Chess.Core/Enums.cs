namespace Chess.Core
{
    public enum PieceColor
    {
        White,
        Black
    }

    public enum ChessMoveType
    {
        Quiet,
        Capture,
        Promotion,
        EnPassant,
        KingsideCastling,
        QueensideCastling,
        Check,
        Checkmate
    }
}