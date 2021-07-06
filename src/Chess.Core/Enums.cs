namespace Chess.Core
{
    public enum PieceColor
    {
        White,
        Black
    }

    public enum ChessMoveType
    {
        QuietMove,
        Capture,
        Promotion,
        EnPassant,
        KingsideCastling,
        QueensideCastling,
        Check,
        Checkmate
    }
}