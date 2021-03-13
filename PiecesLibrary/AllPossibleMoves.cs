using ChessValidator.KingPiece;
using ChessValidator.KnightPiece;
using ChessValidator.Movements;
using ChessValidator.PawnPiece;
using ChessValidator.QueenPiece;
using ChessValidator.RookPiece;
using System.Collections.Generic;
using System.Linq;
using ChessValidator.BishopPiece;

namespace ChessValidator.PiecesLibrary {
    internal class AllPossibleMoves {
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        private static readonly Dictionary<int, string> WhiteDictionary = ChessPieces.WhiteChessPieces.Item1;
        private static readonly Dictionary<int, string> BlackDictionary = ChessPieces.BlackChessPieces.Item1;
        public static readonly ProtectKingMoves ProtectKingMoves = new ProtectKingMoves();
        public readonly Dictionary<string, List<int>> AllWhitePossibleMovesDict;
        public readonly Dictionary<string, List<int>> AllBlackPossibleMovesDict;

        public AllPossibleMoves(bool isInitialized) {
            AllWhitePossibleMovesDict = GetAllWhitePossibleMovesDict(isInitialized);
            AllBlackPossibleMovesDict = GetAllBlackPossibleMovesDict(isInitialized);
        }

        private Pawn _pawnUnit;
        private King _kingUnit;
        private Queen _queenUnit;
        private Bishop _bishopUnit;
        private Knight _knightUnit;
        private Rook _rookUnit;

        private Dictionary<string, List<int>> GetAllWhitePossibleMovesDict(bool isInitialized) {
            var results = new Dictionary<string, List<int>>();
            foreach (var item in WhiteDictionary) {
                var moves = new List<int>();
                var pieceInfo = item.Value + item.Key;
                var input = pieceInfo.ToCharArray();
                switch (item.Value) {
                    case "p":
                        _pawnUnit = new Pawn(UnitColor.White, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.PotentialWhiteMoves);
                        moves = _pawnUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "q":
                        _queenUnit = new Queen(UnitColor.White, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.CoverKingMoves, ProtectKingMoves.PotentialWhiteMoves);
                        moves = _queenUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "r":
                        _rookUnit = new Rook(UnitColor.White, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.CoverKingMoves, ProtectKingMoves.PotentialWhiteMoves);
                        moves = _rookUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "b":
                        _bishopUnit = new Bishop(UnitColor.White, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.CoverKingMoves, ProtectKingMoves.PotentialWhiteMoves);
                        moves = _bishopUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "k":
                        _kingUnit = new King(UnitColor.White, ProtectKingMoves.PotentialWhiteMoves);
                        moves = _kingUnit.GetPossibleMoves(input);
                        break;
                    case "n":
                        _knightUnit = new Knight(UnitColor.White, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.PotentialWhiteMoves);
                        moves = _knightUnit.GetValidMoves(input, isInitialized);
                        break;
                }
                results.Add(pieceInfo, moves);
            }
            return results;
        }
        private Dictionary<string, List<int>> GetAllBlackPossibleMovesDict(bool isInitialized) {
            var results = new Dictionary<string, List<int>>();
            foreach (var item in BlackDictionary) {
                var moves = new List<int>();
                var pieceInfo = item.Value + item.Key;
                var input = pieceInfo.ToCharArray();
                switch (item.Value) {
                    case "p":
                        _pawnUnit = new Pawn(UnitColor.Black, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.PotentialBlackMoves);
                        moves = _pawnUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "q":
                        _queenUnit = new Queen(UnitColor.Black, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.CoverKingMoves, ProtectKingMoves.PotentialBlackMoves);
                        moves = _queenUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "r":
                        _rookUnit = new Rook(UnitColor.Black, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.CoverKingMoves, ProtectKingMoves.PotentialBlackMoves);
                        moves = _rookUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "b":
                        _bishopUnit = new Bishop(UnitColor.Black, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.CoverKingMoves, ProtectKingMoves.PotentialBlackMoves);
                        moves = _bishopUnit.GetValidMoves(input, isInitialized);
                        break;
                    case "k":
                        _kingUnit = new King(UnitColor.Black, ProtectKingMoves.PotentialBlackMoves);
                        moves = _kingUnit.GetPossibleMoves(input);
                        break;
                    case "n":
                        _knightUnit = new Knight(UnitColor.Black, ProtectKingMoves.ProtectWhiteKingMoves, ProtectKingMoves.ProtectBlackKingMoves, ProtectKingMoves.PotentialBlackMoves);
                        moves = _knightUnit.GetValidMoves(input, isInitialized);
                        break;
                }
                results.Add(pieceInfo, moves);
            }
            return results;
        }
    }

    internal class AllValidMoves {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private static AllPossibleMoves _possibleMoves = new AllPossibleMoves(true);
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        private static readonly Dictionary<int, string> WhiteDictionary = ChessPieces.WhiteChessPieces.Item1;
        private static readonly Dictionary<int, string> BlackDictionary = ChessPieces.BlackChessPieces.Item1;
        private static Dictionary<string, List<int>> _allPossibleWhiteMovesDict;
        private static Dictionary<string, List<int>> _allPossibleBlackMovesDict;

        public AllValidMoves() {
            _possibleMoves = new AllPossibleMoves(false);
            _allPossibleWhiteMovesDict = _possibleMoves.AllWhitePossibleMovesDict;
            _allPossibleBlackMovesDict = _possibleMoves.AllBlackPossibleMovesDict;
        }
        public Dictionary<string, List<int>> GetWhiteValidMoves() {
            var coverKingMoves = AllPossibleMoves.ProtectKingMoves.CoverKingMoves; // Protect from Potential Threat
            var protectKingMoves = AllPossibleMoves.ProtectKingMoves.ProtectWhiteKingMoves; // Protect from Active Threat
            var enemyPotentialMoves = AllPossibleMoves.ProtectKingMoves.PotentialBlackMoves;
            
            var enemyPossibleMovesSet = GetEnemyPossibleMovesSet(_allPossibleBlackMovesDict);
            
            GetKingValidMoves(enemyPotentialMoves, enemyPossibleMovesSet, WhiteDictionary, _allPossibleWhiteMovesDict);

            GetGenerateValidMoves(coverKingMoves, protectKingMoves, WhiteDictionary, _allPossibleWhiteMovesDict);



            return _allPossibleWhiteMovesDict;
        }
        public Dictionary<string, List<int>> GetBlackValidMoves() {
            var coverKingMoves = AllPossibleMoves.ProtectKingMoves.CoverKingMoves; // Protect from Potential Threat
            var protectKingMoves = AllPossibleMoves.ProtectKingMoves.ProtectBlackKingMoves; // Protect from Active Threat
            var enemyPotentialMoves = AllPossibleMoves.ProtectKingMoves.PotentialWhiteMoves;

            GetGenerateValidMoves(coverKingMoves, protectKingMoves, BlackDictionary, _allPossibleBlackMovesDict);

            var enemyPossibleMovesSet = GetEnemyPossibleMovesSet(_allPossibleWhiteMovesDict);

            GetKingValidMoves(enemyPotentialMoves, enemyPossibleMovesSet, BlackDictionary, _allPossibleBlackMovesDict);

            return _allPossibleBlackMovesDict;
        }
        private static void GetGenerateValidMoves(Dictionary<int, List<int>> coverKingMoves, HashSet<int> protectKingMoves, Dictionary<int, string> generalAllyDict, Dictionary<string, List<int>> allPossibleAllyMoveDict) {
            foreach (var chessPiece in coverKingMoves) {
                var validMoves = new List<int>();
                var coord = chessPiece.Key;
                if (generalAllyDict.ContainsKey(coord)) {
                    var piece = generalAllyDict[coord];
                    var pieceInfo = piece + coord;
                    if (protectKingMoves.Count == 0) {
                        foreach (var item in allPossibleAllyMoveDict[pieceInfo]) {
                            if (coverKingMoves[coord].Contains(item)) {
                                validMoves.Add(item);
                            }
                        }
                    }
                    _allPossibleWhiteMovesDict[pieceInfo] = validMoves;
                }
            }
        }
        private static HashSet<int> GetEnemyPossibleMovesSet(Dictionary<string, List<int>> allPossibleEnemyMovesDict) {
            var enemyPossibleMovesSet = new HashSet<int>();
            var coordToRemove = new List<int>();
            foreach (var piece in allPossibleEnemyMovesDict) {
                if (piece.Key.StartsWith("p")) {
                    var currentCoordinate = int.Parse(piece.Key.Substring(1, 2));
                    foreach(var coord in piece.Value) {
                        if (coord == currentCoordinate + 10 || coord == currentCoordinate - 10 || coord == currentCoordinate + 20 || coord == currentCoordinate - 20) {
                            coordToRemove.Add(coord);
                        }
                    }
                }
            }
            foreach (var piece in allPossibleEnemyMovesDict) {
                foreach (var coordinate in piece.Value) {
                    enemyPossibleMovesSet.Add(coordinate);
                }
            }
            foreach (var coordinate in coordToRemove) {
                enemyPossibleMovesSet.Remove(coordinate);
            }

            return enemyPossibleMovesSet;
        }
        private static void GetKingValidMoves(HashSet<int> enemyPotentialMoves, HashSet<int> enemyPossibleMovesSet, Dictionary<int, string> generalAllyDict, Dictionary<string, List<int>> allPossibleAllyMovesDict) {
            var kingsValidMoves = new List<int>();
            var kingCoord = "k" + generalAllyDict.FirstOrDefault(x => x.Value == "k").Key;
            if (kingCoord != "k0") {
                var allyKingPossibleMoves = allPossibleAllyMovesDict[kingCoord];
                foreach (var item in allyKingPossibleMoves) {
                    if (!enemyPossibleMovesSet.Contains(item) && !enemyPotentialMoves.Contains(item)) {
                        kingsValidMoves.Add(item);
                    }
                }
            }
            allPossibleAllyMovesDict[kingCoord] = kingsValidMoves;
        }

    }
}
