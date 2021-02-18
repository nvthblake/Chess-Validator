using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessValidator.Location;
using ChessValidator.PawnPiece;
using ChessValidator.QueenPiece;

namespace ChessValidator {
    class Program {
        private static readonly string[,] chessBoard = new string[8, 8];
        private static readonly BlackUnits blackUnits = new BlackUnits();
        private static readonly WhiteUnits whiteUnits = new WhiteUnits();

        private static void Main(string[] arg) {
            do {
                PopulateChessboard(); // Populate chessboard array with pieces' inputs from input.txt
                DrawChessBoard(); // Drawup a chessboard using chessboard array
                Console.Write("enter piece location: ");
                var inputString = Console.ReadLine();
                string checkedPiece = CheckAndGetPiece(inputString);

                if (!string.IsNullOrEmpty(checkedPiece)) {
                    char[] inputChar = checkedPiece.ToCharArray();
                    GetValidMoves(inputChar);
                }

                else Console.WriteLine("There is no such piece");
                Console.WriteLine("Press Anything to Continue");
                Console.ReadLine();

            } while (true);
        }

        private static void GetValidMoves(char[] input) {
            var pawn = new Pawn();
            var queen = new Queen();
            List<int> moves = new List<int>();

            if (input[0] == 'p' || input[0] == 'P') {
                moves = pawn.ValidMoves(input);
            }
            else if (input[0] == 'q' || input[0] == 'Q') {
                moves = queen.ValidMoves(input);
            }
            foreach (var item in moves) {
                int row = (item / 10) - 1;
                int col = (item % 10) - 1;
                chessBoard[row, col] = "x";
            }
            DrawChessBoard();
        }
        private static void PopulateChessboard() {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Users\nvthblake\Github\Chess-Validator\input.txt");
            Console.WriteLine("WHITE: " + lines[0]);
            Console.WriteLine("BLACK: " + lines[1]);

            var whitePiece = whiteUnits.GetPieces();
            var blackPiece = blackUnits.GetPieces();

            // Create a 8x8 blank chessBoard array:
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    if ((row + col) % 2 == 0) {
                        chessBoard[row, col] = " ";
                    }
                    else {
                        chessBoard[row, col] = " ";
                    }
                }
            }

            foreach (var item in whitePiece) {
                char[] charArray;
                charArray = item.ToCharArray();
                int row = Int32.Parse(charArray[1].ToString()) - 1;
                int col = Int32.Parse(charArray[2].ToString()) - 1;
                chessBoard[row, col] = charArray[0].ToString().ToUpper();
            }

            foreach (var item in blackPiece) {
                char[] charArray;
                charArray = item.ToCharArray();
                int row = Int32.Parse(charArray[1].ToString()) - 1;
                int col = Int32.Parse(charArray[2].ToString()) - 1;
                chessBoard[row, col] = charArray[0].ToString().ToLower();
            }
        }

        private static void DrawChessBoard() {
            Console.WriteLine("     1   2   3   4   5   6   7   8");
            Console.WriteLine("   ---------------------------------");
            for (int row = 0; row < 8; row++) {
                Console.Write(" " + (row + 1) + " | ");
                for (int col = 0; col < 8; col++) {
                    Console.Write(chessBoard[row, col] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("   ---------------------------------");
            }
        }

        private static string CheckAndGetPiece(string inputString) {
            var blackDictionary = blackUnits.GetPiecesDictionary();
            var whiteDictionary = whiteUnits.GetPiecesDictionary();

            string inputPiece = inputString.Substring(0, 1);
            int inputCoordinate = Int32.Parse(inputString.Substring(1));

            if (blackDictionary.ContainsKey(inputCoordinate) && blackDictionary[inputCoordinate].ToLower() == inputPiece.ToLower()) {
                return inputPiece.ToLower() + inputCoordinate.ToString();
            }
            else if (whiteDictionary.ContainsKey(inputCoordinate) && whiteDictionary[inputCoordinate].ToLower() == inputPiece.ToLower()) {
                return inputPiece.ToUpper() + inputCoordinate.ToString();
            }

            return string.Empty;
        }
    }
}
