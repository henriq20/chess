namespace Chess.Core.Board
{
    public interface IChessBoard
    {
        /// <summary>
        /// Gets the length of the board.
        /// </summary>
        int Length { get; }
        
        /// <summary>
        /// Gets a square of the board by specifing its name.
        /// <para>
        /// E.g: "a2", "h7".
        /// </para>
        /// </summary>
        Square this[string name] { get; }

        /// <summary>
        /// Gets a square of the board by specifing its row and column.
        /// </summary>
        Square this[int row, int column] { get; }

        /// <summary>
        /// Places all pieces in their starting positions.
        /// <para>
        /// For each side of the board it will be placed: 1 King, 1 Queen, 2 Rooks, 2 Bishops, 2 Knights, and 8 Pawns.
        /// </para>
        /// </summary>
        void Setup();

        /// <summary>
        /// Clears the board by removing the piece from each square.
        /// </summary>
        void Clear();
    }
}