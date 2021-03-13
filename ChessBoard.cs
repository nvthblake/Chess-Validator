using System;
using ChessValidator.PiecesLibrary;

namespace ChessValidator {
    internal class ChessBoard {
        private static ChessPieces _chessPieces;

        public void GetDrawChessBoard(string[,] chessBoardArray) {
            Console.WriteLine("   ---------------------------------");
            for (var row = 7; row > -1; row--) {
                Console.Write(" " + (row + 1) + " | ");
                for (var col = 0; col < 8; col++) {
                    Console.Write(chessBoardArray[row, col] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("   ---------------------------------");
            }
            Console.WriteLine("     1   2   3   4   5   6   7   8");
        }

        public void GetPopulateChessboard(string[,] chessBoardArray) {
            _chessPieces = new ChessPieces();
            Console.WriteLine("WHITE: " + Input.WhitePieces);
            Console.WriteLine("BLACK: " + Input.BlackPieces);

            var whitePiece = _chessPieces.WhitePieces;
            var blackPiece = _chessPieces.BlackPieces;

            for (var row = 0; row < 8; row++) {
                for (var col = 0; col < 8; col++) {
                    chessBoardArray[row, col] = " ";
                }
            }

            foreach (var item in whitePiece) {
                var charArray = item.ToCharArray();
                var row = int.Parse(charArray[1].ToString()) - 1;
                var col = int.Parse(charArray[2].ToString()) - 1;
                chessBoardArray[row, col] = charArray[0].ToString().ToUpper();
            }

            foreach (var item in blackPiece) {
                var charArray = item.ToCharArray();
                var row = int.Parse(charArray[1].ToString()) - 1;
                var col = int.Parse(charArray[2].ToString()) - 1;
                chessBoardArray[row, col] = charArray[0].ToString().ToLower();
            }
        }
    }
}
