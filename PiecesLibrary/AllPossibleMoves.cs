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
        public readonly Dictionary<string, List<int>> allWhitePossibleMovesDict;
        public readonly Dictionary<string, List<int>> allBlackPossibleMovesDict;

        public AllPossibleMoves(bool isInitialized) {
            allWhitePossibleMovesDict = GetAllWhitePossibleMovesDict(isInitialized);
            allBlackPossibleMovesDict = GetAllBlackPossibleMovesDict(isInitialized);
        }

        Pawn pawnUnit;
        King kingUnit;
        Queen queenUnit;
        Bishop bishopUnit;
        Knight knightUnit;
        Rook rookUnit;

        public Dictionary<string, List<int>> GetAllWhitePossibleMovesDict(bool isInitialized) {
            Dictionary<string, List<int>> results = new Dictionary<string, List<int>>();
            foreach (var item in whiteDictionary) {
                List<int> moves = new List<int>();
                string pieceInfo = item.Value + item.Key.ToString();
                char[] input = pieceInfo.ToCharArray();
                switch (item.Value) {
                    case "p":
                        pawnUnit = new Pawn(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = pawnUnit.ValidMoves(input);
                        break;
                    case "q":
                        queenUnit = new Queen(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = queenUnit.ValidMoves(input, isInitialized);
                        break;
                    case "r":
                        rookUnit = new Rook(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = rookUnit.ValidMoves(input, isInitialized);
                        break;
                    case "b":
                        bishopUnit = new Bishop(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = bishopUnit.ValidMoves(input, isInitialized);
                        break;
                    case "k":
                        kingUnit = new King(UnitColor.WHITE, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = kingUnit.PossibleMoves(input);
                        break;
                    case "n":
                        knightUnit = new Knight(UnitColor.WHITE, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.PotentialWhiteMoves);
                        moves = knightUnit.ValidMoves(input, isInitialized);
                        break;
                }
                results.Add(pieceInfo, moves);
            }
            return results;
        }
        public Dictionary<string, List<int>> GetAllBlackPossibleMovesDict(bool isInitialized) {
            Dictionary<string, List<int>> results = new Dictionary<string, List<int>>();
            foreach (var item in blackDictionary) {
                List<int> moves = new List<int>();
                string pieceInfo = item.Value + item.Key.ToString();
                char[] input = pieceInfo.ToCharArray();
                switch (item.Value) {
                    case "p":
                        pawnUnit = new Pawn(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = pawnUnit.ValidMoves(input);
                        break;
                    case "q":
                        queenUnit = new Queen(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = queenUnit.ValidMoves(input, isInitialized);
                        break;
                    case "r":
                        rookUnit = new Rook(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = rookUnit.ValidMoves(input, isInitialized);
                        break;
                    case "b":
                        bishopUnit = new Bishop(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.CoverKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = bishopUnit.ValidMoves(input, isInitialized);
                        break;
                    case "k":
                        kingUnit = new King(UnitColor.BLACK, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = kingUnit.PossibleMoves(input);
                        break;
                    case "n":
                        knightUnit = new Knight(UnitColor.BLACK, protectKingMoves.ProtectWhiteKingMoves, protectKingMoves.ProtectBlackKingMoves, protectKingMoves.PotentialBlackMoves);
                        moves = knightUnit.ValidMoves(input, isInitialized);
                        break;
                }
                results.Add(pieceInfo, moves);
            }
            return results;
        }
    }

    class AllValidMoves {
        static AllPossibleMoves possibleMoves = new AllPossibleMoves(true);
        private static readonly ChessPieces chessPieces = new ChessPieces();
        private static readonly Dictionary<int, string> whiteDictionary = chessPieces.whiteChessPieces.Item1;
        private static readonly Dictionary<int, string> blackDictionary = chessPieces.blackChessPieces.Item1;
        private static Dictionary<string, List<int>> allPossibleWhiteMovesDict;
        private static Dictionary<string, List<int>> allPossibleBlackMovesDict;

        public AllValidMoves() {
            possibleMoves = new AllPossibleMoves(false);
            allPossibleWhiteMovesDict = possibleMoves.allWhitePossibleMovesDict;
            allPossibleBlackMovesDict = possibleMoves.allBlackPossibleMovesDict;
        }
        public Dictionary<string, List<int>> GetWhiteValidMoves() {
            var coverKingMoves = AllPossibleMoves.protectKingMoves.CoverKingMoves; // Protect from Potential Threat
            var protectKingMoves = AllPossibleMoves.protectKingMoves.ProtectWhiteKingMoves; // Protect from Active Threat
            var enemyPotentialMoves = AllPossibleMoves.protectKingMoves.PotentialBlackMoves;

            GenerateValidMoves(coverKingMoves, protectKingMoves, whiteDictionary, allPossibleWhiteMovesDict);

            HashSet<int> enemyPossibleMovesSet = GetEnemyPossibleMovesSet(allPossibleBlackMovesDict);

            GetKingValidMoves(enemyPotentialMoves, enemyPossibleMovesSet, whiteDictionary, allPossibleWhiteMovesDict);

            return allPossibleWhiteMovesDict;
        }
        public Dictionary<string, List<int>> GetBlackValidMoves() {
            var coverKingMoves = AllPossibleMoves.protectKingMoves.CoverKingMoves; // Protect from Potential Threat
            var protectKingMoves = AllPossibleMoves.protectKingMoves.ProtectBlackKingMoves; // Protect from Active Threat
            var enemyPotentialMoves = AllPossibleMoves.protectKingMoves.PotentialWhiteMoves;

            GenerateValidMoves(coverKingMoves, protectKingMoves, blackDictionary, allPossibleBlackMovesDict);

            HashSet<int> enemyPossibleMovesSet = GetEnemyPossibleMovesSet(allPossibleWhiteMovesDict);

            GetKingValidMoves(enemyPotentialMoves, enemyPossibleMovesSet, blackDictionary, allPossibleBlackMovesDict);

            return allPossibleBlackMovesDict;
        }
        private static void GenerateValidMoves(Dictionary<int, List<int>> coverKingMoves, HashSet<int> protectKingMoves, Dictionary<int, string> generalAllyDict, Dictionary<string, List<int>> allPossibleAllyMoveDict) {
            foreach (var chessPiece in coverKingMoves) {
                List<int> validMoves = new List<int>();
                var coord = chessPiece.Key;
                if (generalAllyDict.ContainsKey(coord)) {
                    var piece = generalAllyDict[coord];
                    var pieceInfo = piece + coord.ToString();
                    if (protectKingMoves.Count == 0) {
                        foreach (var item in allPossibleAllyMoveDict[pieceInfo]) {
                            if (coverKingMoves[coord].Contains(item)) {
                                validMoves.Add(item);
                            }
                        }
                    }
                    allPossibleWhiteMovesDict[pieceInfo] = validMoves;
                }
            }
        }
        private static HashSet<int> GetEnemyPossibleMovesSet(Dictionary<string, List<int>> allPossibleEnemyMovesDict) {
            HashSet<int> enemyPossibleMovesSet = new HashSet<int>();
            foreach (var piece in allPossibleEnemyMovesDict) {
                foreach (var coordinate in piece.Value) {
                    enemyPossibleMovesSet.Add(coordinate);
                }
            }

            return enemyPossibleMovesSet;
        }
        private static void GetKingValidMoves(HashSet<int> enemyPotentialMoves, HashSet<int> enemyPossibleMovesSet, Dictionary<int, string> generalAllyDict, Dictionary<string, List<int>> allPossibleAllyMovesDict) {
            List<int> kingsValidMoves = new List<int>();
            var kingCoord = "k" + generalAllyDict.FirstOrDefault(x => x.Value == "k").Key.ToString();
            var allyKingPossibleMoves = allPossibleAllyMovesDict[kingCoord];
            foreach (var item in allyKingPossibleMoves) {
                if (!enemyPossibleMovesSet.Contains(item) && !enemyPotentialMoves.Contains(item)) {
                    kingsValidMoves.Add(item);
                }
            }
            allPossibleAllyMovesDict[kingCoord] = kingsValidMoves;
        }

    }
}
