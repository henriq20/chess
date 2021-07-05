namespace Chess.Core.Board
{
    public interface IChessBoard
    {
        /// <summary>
        /// Gets a multidimensional array with all the squares on the chessboard.
        /// </summary>
        Square[,] Squares { get; }
        
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