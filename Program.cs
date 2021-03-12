using ChessValidator.PiecesLibrary;
using System;
using System.Collections.Generic;

namespace ChessValidator {
    class Program {
        private static string[,] _chessBoard;
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        private static readonly AllValidMoves AllValidMoves = new AllValidMoves();

        private static void Main(string[] arg) {
            _chessBoard = new string[8, 8];
            do {
                var allWhitePossibleMoves = AllValidMoves.GetWhiteValidMoves();
                var allBlackPossibleMoves = AllValidMoves.GetBlackValidMoves();
                GetPopulateChessboard(); // Populate chessboard array with pieces' inputs from input.txt
                GetDrawChessBoard(); // Draw up a chessboard using chessboard array
                Console.Write("enter piece location: ");
                var inputString = Console.ReadLine();
                var checkedPiece = GetCheckAndGetPiece(inputString);

                if (!string.IsNullOrEmpty(checkedPiece)) {
                    //char[] inputChar = checkedPiece.ToCharArray();
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
                    var row = (item / 10) - 1;
                    var col = (item % 10) - 1;
                    _chessBoard[row, col] = ".";
                }
            }
            GetDrawChessBoard();
        }
        private static void GetPopulateChessboard() {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Users\nvthblake\Github\Chess-Validator\input.txt");
            Console.WriteLine("WHITE: " + lines[0]);
            Console.WriteLine("BLACK: " + lines[1]);

            var whitePiece = ChessPieces.WhitePieces;
            var blackPiece = ChessPieces.BlackPieces;

            // Create a 8x8 blank chessBoard array:
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    if ((row + col) % 2 == 0) {
                        _chessBoard[row, col] = " ";
                    }
                    else {
                        _chessBoard[row, col] = " ";
                    }
                }
            }

            foreach (var item in whitePiece) {
                var charArray = item.ToCharArray();
                var row = int.Parse(charArray[1].ToString()) - 1;
                var col = int.Parse(charArray[2].ToString()) - 1;
                _chessBoard[row, col] = charArray[0].ToString().ToUpper();
            }

            foreach (var item in blackPiece) {
                var charArray = item.ToCharArray();
                var row = int.Parse(charArray[1].ToString()) - 1;
                var col = int.Parse(charArray[2].ToString()) - 1;
                _chessBoard[row, col] = charArray[0].ToString().ToLower();
            }
        }

        private static void GetDrawChessBoard() {
            Console.WriteLine("     1   2   3   4   5   6   7   8");
            Console.WriteLine("   ---------------------------------");
            for (int row = 0; row < 8; row++) {
                Console.Write(" " + (row + 1) + " | ");
                for (int col = 0; col < 8; col++) {
                    Console.Write(_chessBoard[row, col] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("   ---------------------------------");
            }
        }

        private static string GetCheckAndGetPiece(string inputString) {
            var blackDictionary = ChessPieces.BlackChessPieces.Item1;
            var whiteDictionary = ChessPieces.WhiteChessPieces.Item1;

            string inputPiece = inputString.Substring(0, 1);
            int inputCoordinate = int.Parse(inputString.Substring(1));

            if (blackDictionary.ContainsKey(inputCoordinate) && blackDictionary[inputCoordinate].ToLower() == inputPiece.ToLower()) {
                return inputPiece.ToLower() + inputCoordinate.ToString();
            }
            else if (whiteDictionary.ContainsKey(inputCoordinate) && whiteDictionary[inputCoordinate].ToLower() == inputPiece.ToLower()) {
                return inputPiece.ToLower() + inputCoordinate.ToString();
            }

            return string.Empty;
        }
    }
}
