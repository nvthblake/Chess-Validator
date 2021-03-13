using ChessValidator.PiecesLibrary;
using System;
using System.Collections.Generic;

namespace ChessValidator {
    internal static class Program {
        private static string[,] _chessBoardArray;
        private static ChessPieces _chessPieces;
        private static AllValidMoves _allValidMoves;
        private static ChessBoard _chessBoard;

        // ReSharper disable once InconsistentNaming
        public static void Main()
        {
            _chessPieces = new ChessPieces();
            _allValidMoves = new AllValidMoves();
            _chessBoardArray = new string[8, 8];
            _chessBoard = new ChessBoard();
            do {
                var allWhitePossibleMoves = _allValidMoves.GetWhiteValidMoves();
                var allBlackPossibleMoves = _allValidMoves.GetBlackValidMoves();
                _chessBoard.GetPopulateChessboard(_chessBoardArray); // Populate chessboard array with pieces' inputs from input.txt
                _chessBoard.GetDrawChessBoard(_chessBoardArray); // Draw up a chessboard
                Console.Write("enter piece location: ");
                var inputString = Console.ReadLine();
                var checkedPiece = GetCheckAndGetPiece(inputString);

                if (!string.IsNullOrEmpty(checkedPiece)) {
                    GetValidMoves(checkedPiece, allWhitePossibleMoves, allBlackPossibleMoves);
                }

                else Console.WriteLine("There is no such piece");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();

            } while (true);
            // ReSharper disable once FunctionNeverReturns
        }

        private static void GetValidMoves(string input, Dictionary<string, List<int>> allWhiteMoves, Dictionary<string, List<int>> allBlackMoves) {
            var moves = allWhiteMoves.ContainsKey(input) ? allWhiteMoves[input] : allBlackMoves[input];

            // Draw up all possible moves on chessboard array
            foreach (var item in moves) {
                if (item > 0) {
                    var row = item / 10 - 1;
                    var col = item % 10 - 1;
                    _chessBoardArray[row, col] = ".";
                }
            }
            _chessBoard.GetDrawChessBoard(_chessBoardArray);
            Console.WriteLine("All possible moves: ");
            foreach (var item in moves) {
                if (item != 0)
                    Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static string GetCheckAndGetPiece(string inputString) {
            var blackDictionary = _chessPieces.BlackChessPieces.Item1;
            var whiteDictionary = _chessPieces.WhiteChessPieces.Item1;

            var inputPiece = inputString.Substring(0, 1);
            var inputCoordinate = int.Parse(inputString.Substring(1));

            if (blackDictionary.ContainsKey(inputCoordinate) && blackDictionary[inputCoordinate].ToLower() == inputPiece.ToLower()) {
                return inputPiece.ToLower() + inputCoordinate;
            }
            if (whiteDictionary.ContainsKey(inputCoordinate) && whiteDictionary[inputCoordinate].ToLower() == inputPiece.ToLower()) {
                return inputPiece.ToLower() + inputCoordinate;
            }

            return string.Empty;
        }
    }
}
