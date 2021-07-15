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
        EnPassant,
        Promotion,
        KingsideCastling,
        QueensideCastling
    }
}