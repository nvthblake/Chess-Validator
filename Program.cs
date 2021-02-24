using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessValidator.KingPiece;
using ChessValidator.KnightPiece;
using ChessValidator.Location;
using ChessValidator.PawnPiece;
using ChessValidator.QueenPiece;
using ChessValidator.RookPiece;

namespace ChessValidator {
    class Program {
        private static readonly string[,] chessBoard = new string[8, 8];
        private static readonly ChessPieces chessPieces = new ChessPieces();

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
            Pawn pawnUnit;
            King kingUnit;
            Queen queenUnit;
            Rook rookUnit;
            Bishop bishopUnit;
            Knight knightUnit;
            List<int> moves = new List<int>();

            switch (input[0]) {
                case 'p':
                case 'P':
                    pawnUnit = input[0] == 'p' ? new Pawn(UnitColor.BLACK) : new Pawn(UnitColor.WHITE);
                    moves = pawnUnit.ValidMoves(input);
                    break;
                case 'q':
                case 'Q':
                    queenUnit = input[0] == 'q' ? new Queen(UnitColor.BLACK) : new Queen(UnitColor.WHITE);
                    moves = queenUnit.ValidMoves(input);
                    break;
                case 'r':
                case 'R':
                    rookUnit = input[0] == 'r' ? new Rook(UnitColor.BLACK) : new Rook(UnitColor.WHITE);
                    moves = rookUnit.ValidMoves(input);
                    break;
                case 'b':
                case 'B':
                    bishopUnit = input[0] == 'b' ? new Bishop(UnitColor.BLACK) : new Bishop(UnitColor.WHITE);
                    moves = bishopUnit.ValidMoves(input);
                    break;
                case 'k':
                case 'K':
                    kingUnit = input[0] == 'k' ? new King(UnitColor.BLACK) : new King(UnitColor.WHITE);
                    moves = kingUnit.ValidMoves(input);
                    break;
                case 'n':
                case 'N':
                    knightUnit = input[0] == 'n' ? new Knight(UnitColor.BLACK) : new Knight(UnitColor.WHITE);
                    moves = knightUnit.ValidMoves(input);
                    break;
            }

            // Draw up all possible moves on chessboard array
            foreach (var item in moves) {
                int row = (item / 10) - 1;
                int col = (item % 10) - 1;
                chessBoard[row, col] = ".";
            }
            DrawChessBoard();
        }
        private static void PopulateChessboard() {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Users\nvthblake\Github\Chess-Validator\input.txt");
            Console.WriteLine("WHITE: " + lines[0]);
            Console.WriteLine("BLACK: " + lines[1]);

            var whitePiece = chessPieces.whitePieces;
            var blackPiece = chessPieces.blackPieces;

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
            var blackDictionary = chessPieces.blackChessPieces.Item1;
            var whiteDictionary = chessPieces.whiteChessPieces.Item1;

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
