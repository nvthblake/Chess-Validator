using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessValidator.Location;
using ChessValidator.PawnPiece;

namespace ChessValidator {
    class Program {
        private static string[,] chessBoard = new string[8, 8];
        static void Main(string[] args) {
            do {
                populateChessboard(); // Populate chessboard array with pieces' inputs from input.txt
                drawChessBoard(); // Drawup a chessboard using chessboard array
                Console.Write("enter piece location: ");
                var inputString = Console.ReadLine();
                string checkedPiece = checkPiece(inputString);

                if (!string.IsNullOrEmpty(checkedPiece)) {
                    char[] inputChar = checkedPiece.ToCharArray();
                    getValidMoves(inputChar);
                }

                else Console.WriteLine("There is no such piece");
                Console.WriteLine("Press Anything to Continue");
                Console.ReadLine();

            } while (true);

            Console.ReadLine();
            
        }

        private static void getValidMoves(char[] input) {
            var pawn = new Pawn();
            List<int> moves = new List<int>();

            if (input[0] == 'p' || input[0] == 'P') {
                moves = pawn.ValidMoves(input);
            }
            foreach (var item in moves) {
                int row = item / 10;
                int col = item % 10;
                chessBoard[row, col] = "x";
            }
            drawChessBoard();
        }
        private static void populateChessboard() {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nvthblake\Desktop\Net Core\Project\ChessValidator\input.txt");
            Console.WriteLine("WHITE: " + lines[0]);
            Console.WriteLine("BLACK: " + lines[1]);

            var blackUnits = new BlackUnits();
            var whiteUnits = new WhiteUnits();
            var whitePiece = whiteUnits.getPieces();
            var blackPiece = blackUnits.getPieces();

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
                int row = Int32.Parse(charArray[1].ToString());
                int col = Int32.Parse(charArray[2].ToString());
                chessBoard[row, col] = charArray[0].ToString().ToUpper();
            }

            foreach (var item in blackPiece) {
                char[] charArray;
                charArray = item.ToCharArray();
                int row = Int32.Parse(charArray[1].ToString());
                int col = Int32.Parse(charArray[2].ToString());
                chessBoard[row, col] = charArray[0].ToString().ToLower();
            }
        }

        private static void drawChessBoard() {
            Console.WriteLine("     0   1   2   3   4   5   6   7");
            Console.WriteLine("   ---------------------------------");
            for (int row = 0; row < 8; row++) {
                Console.Write(" " + row + " | ");
                for (int col = 0; col < 8; col++) {
                    Console.Write(chessBoard[row, col] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("   ---------------------------------");
            }
        }

        private static string checkPiece(string inputString) {
            var blackUnits = new BlackUnits();
            var whiteUnits = new WhiteUnits();

            var blackDictionary = blackUnits.getPiecesDictionary();
            var whiteDictionary = whiteUnits.getPiecesDictionary();

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
