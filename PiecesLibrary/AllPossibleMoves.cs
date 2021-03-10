using ChessValidator.KingPiece;
using ChessValidator.KnightPiece;
using ChessValidator.Movements;
using ChessValidator.PawnPiece;
using ChessValidator.QueenPiece;
using ChessValidator.RookPiece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.PiecesLibrary {
    class AllPossibleMoves {
        private static readonly ChessPieces chessPieces = new ChessPieces();
        private static readonly Dictionary<int, string> whiteDictionary = chessPieces.whiteChessPieces.Item1;
        private static readonly Dictionary<int, string> blackDictionary = chessPieces.blackChessPieces.Item1;
        public static readonly ProtectKingMoves protectKingMoves = new ProtectKingMoves();
        Pawn pawnUnit;
        King kingUnit;
        Queen queenUnit;
        Bishop bishopUnit;
        Knight knightUnit;
        Rook rookUnit;

        public Dictionary<string, List<int>> GetAllWhitePossibleMovesDict() {
            Dictionary<string, List<int>> results = new Dictionary<string, List<int>>();
            foreach (var item in whiteDictionary) {
                List<int> moves = new List<int>();
                string pieceInfo = item.Value + item.Key.ToString();
                char[] input = pieceInfo.ToCharArray();
                switch (item.Value) {
                    case "p":
                        pawnUnit = new Pawn(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves);
                        moves = pawnUnit.ValidMoves(input);
                        break;
                    case "q":
                        queenUnit = new Queen(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = queenUnit.ValidMoves(input);
                        break;
                    case "r":
                        rookUnit = new Rook(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = rookUnit.ValidMoves(input);
                        break;
                    case "b":
                        bishopUnit = new Bishop(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = bishopUnit.ValidMoves(input);
                        break;
                    case "k":
                        kingUnit = new King(UnitColor.WHITE, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = kingUnit.PossibleMoves(input);
                        break;
                    case "n":
                        knightUnit = new Knight(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = knightUnit.ValidMoves(input);
                        break;
                }
                results.Add(pieceInfo, moves);
            }
            return results;
        }
        public Dictionary<string, List<int>> GetAllBlackPossibleMovesDict() {
            Dictionary<string, List<int>> results = new Dictionary<string, List<int>>();
            foreach (var item in blackDictionary) {
                List<int> moves = new List<int>();
                string pieceInfo = item.Value + item.Key.ToString();
                char[] input = pieceInfo.ToCharArray();
                switch (item.Value) {
                    case "p":
                        pawnUnit = new Pawn(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves);
                        moves = pawnUnit.ValidMoves(input);
                        break;
                    case "q":
                        queenUnit = new Queen(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = queenUnit.ValidMoves(input);
                        break;
                    case "r":
                        rookUnit = new Rook(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = rookUnit.ValidMoves(input);
                        break;
                    case "b":
                        bishopUnit = new Bishop(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = bishopUnit.ValidMoves(input);
                        break;
                    case "k":
                        kingUnit = new King(UnitColor.BLACK, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = kingUnit.PossibleMoves(input);
                        break;
                    case "n":
                        knightUnit = new Knight(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = knightUnit.ValidMoves(input);
                        break;
                }
                results.Add(pieceInfo, moves);
            }
            return results;
        }
    }

    class AllValidMoves {
        readonly AllPossibleMoves possibleMoves = new AllPossibleMoves();
        private static readonly ChessPieces chessPieces = new ChessPieces();
        private static readonly Dictionary<int, string> whiteDictionary = chessPieces.whiteChessPieces.Item1;
        private static readonly Dictionary<int, string> blackDictionary = chessPieces.blackChessPieces.Item1;

        public Dictionary<string, List<int>> GetWhiteValidMoves() {
            var allPossibleWhiteMovesDict = possibleMoves.GetAllWhitePossibleMovesDict();
            var allPossibleBlackMovesDict = possibleMoves.GetAllBlackPossibleMovesDict();
            var coverKingMoves = AllPossibleMoves.protectKingMoves.CoverKingMoves; // Protect from Potential Threat
            var protectKingMoves = AllPossibleMoves.protectKingMoves.ProtectWhiteKingMoves; // Protect from Active Threat
            var enemyPotentialMoves = AllPossibleMoves.protectKingMoves.PotentialBlackMoves; 

            foreach (var chessPiece in coverKingMoves) {
                List<int> validMoves = new List<int>();
                var coord = chessPiece.Key;
                if (whiteDictionary.ContainsKey(coord)) {
                    var piece = whiteDictionary[coord];
                    var pieceInfo = piece + coord.ToString();
                    if (protectKingMoves.Count == 0) {
                        foreach (var item in allPossibleWhiteMovesDict[pieceInfo]) {
                            if (coverKingMoves[coord].Contains(item)) {
                                validMoves.Add(item);
                            }
                        }
                    }
                    allPossibleWhiteMovesDict[pieceInfo] = validMoves;
                }
            }
            HashSet<int> enemyPossibleMovesSet = new HashSet<int>();
            foreach (var piece in allPossibleBlackMovesDict) {
                foreach(var coordinate in piece.Value) {
                    enemyPossibleMovesSet.Add(coordinate);
                }
            }
            List<int> kingsValidMoves = new List<int>();
            var kingCoord = "k" + whiteDictionary.FirstOrDefault(x => x.Value == "k").Key.ToString();
            var allyKingPossibleMoves = allPossibleWhiteMovesDict[kingCoord];
            foreach (var item in allyKingPossibleMoves) {
                if (!enemyPossibleMovesSet.Contains(item) && !enemyPotentialMoves.Contains(item)) {
                    kingsValidMoves.Add(item);
                }
            }
            allPossibleWhiteMovesDict[kingCoord] = kingsValidMoves;
            return allPossibleWhiteMovesDict;
        }

        public Dictionary<string, List<int>> GetBlackValidMoves() {
            var allPossibleBlackMovesDict = possibleMoves.GetAllBlackPossibleMovesDict();
            var allPossibleWhiteMovesDict = possibleMoves.GetAllWhitePossibleMovesDict();
            var coverKingMoves = AllPossibleMoves.protectKingMoves.CoverKingMoves; // Protect from Potential Threat
            var protectKingMoves = AllPossibleMoves.protectKingMoves.ProtectBlackKingMoves; // Protect from Active Threat
            var enemyPotentialMoves = AllPossibleMoves.protectKingMoves.PotentialWhiteMoves;

            // get valid moves for all pieces except King
            foreach (var chessPiece in coverKingMoves) {
                List<int> validMoves = new List<int>();
                var coord = chessPiece.Key;
                if (blackDictionary.ContainsKey(coord)) {
                    var piece = blackDictionary[coord];
                    var pieceInfo = piece + coord.ToString();
                    if (protectKingMoves.Count == 0) {
                        foreach (var item in allPossibleBlackMovesDict[pieceInfo]) {
                            if (coverKingMoves[coord].Contains(item)) {
                                validMoves.Add(item);
                            }
                        }
                    }
                    allPossibleBlackMovesDict[pieceInfo] = validMoves;
                }
            }
            HashSet<int> enemyPossibleMovesSet = new HashSet<int>();
            foreach (var piece in allPossibleWhiteMovesDict) {
                foreach (var coordinate in piece.Value) {
                    enemyPossibleMovesSet.Add(coordinate);
                }
            }

            // get King's valid moves
            List<int> kingsValidMoves = new List<int>();
            var kingCoord = "k" + blackDictionary.FirstOrDefault(x => x.Value == "k").Key.ToString();
            var allyKingPossibleMoves = allPossibleBlackMovesDict[kingCoord];
            foreach (var item in allyKingPossibleMoves) {
                if (!enemyPossibleMovesSet.Contains(item) && !enemyPotentialMoves.Contains(item)) {
                    kingsValidMoves.Add(item);
                }
            }
            allPossibleBlackMovesDict[kingCoord] = kingsValidMoves;
            return allPossibleBlackMovesDict;
        }
    }
}
