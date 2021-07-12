using System;
using Chess.Core.Board;
using Chess.Core.Pieces;

namespace Chess.Core.Extensions
{
    /// <summary>Provides methods for placing the pieces in their starting positions.</summary>
    public static class ChessBoardExtensions
    {
        /// <summary>Places 8 pawns on each side of the board.</summary>
        /// <param name="board">The board to place the pawns.</param>
        public static void PlacePawns(this IChessBoard board)
        {
            _ = board ?? throw new ArgumentNullException(nameof(board), "Cannot pass null to board.");

            for (int column = 0; column < board.Length; column++)
            {
                var whitePawn = new Pawn(PieceColor.White, board);
                var blackPawn = new Pawn(PieceColor.Black, board);

                board[1, column].Place(whitePawn);
                board[6, column].Place(blackPawn);
            }
        }

        /// <summary>Places 1 king on each side of the board.</summary>
        /// <param name="board">The board to place the kings.</param>
        public static void PlaceKings(this IChessBoard board)
        {
            _ = board ?? throw new ArgumentNullException(nameof(board), "Cannot pass null to board.");

            var whiteKing = new King(PieceColor.White, board);
            var blackKing = new King(PieceColor.Black, board);

            board["e1"].Place(whiteKing);
            board["e8"].Place(blackKing);
        }
    }
}