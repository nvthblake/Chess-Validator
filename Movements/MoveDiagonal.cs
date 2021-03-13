using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ChessValidator.Movements {
    [SuppressMessage("ReSharper", "ConvertIfStatementToSwitchStatement")]
    [SuppressMessage("ReSharper", "InvertIf")]
    [SuppressMessage("ReSharper", "ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator")]
    internal class MoveDiagonal : AdjacentCoordinates, IMoveDiagonal {
        private const int Min = 1;
        private const int Max = 8;

        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized) {
            var allPossibleMoves = new AllOrthogonalDiagonalMoves {
                AllForwardLeftMoves = GetAllForwardLeftMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllForwardRightMoves = GetAllForwardRightMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllBackwardLeftMoves = GetAllBackwardLeftMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllBackwardRightMoves = GetAllBackwardRightMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized)
            };
            var mergedList = new List<int>();
            allPossibleMoves.AllForwardLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllForwardRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetAllForwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                                HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                                HashSet<int> potentialMoves, bool isInitialized = false) {
            var allPossibleMoves = new List<int>();
            var results = new List<int>();
            var nextCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };

            while (rowPosition < Max && colPosition < Max) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }
                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleMoves.Add(nextCoordinate);
                                if (enemyKing/10 < Max && enemyKing % 10 < Max) {
                                    potentialMoves.Add(enemyKing + 11);
                                }
                            }
                            else if (numberEnemyPieceEncountered == 1) {
                                if (!coverKingMoves.ContainsKey(firstEnemyEncountered)) {
                                    coverKingMoves.Add(firstEnemyEncountered, allMovesToKing);
                                }
                            }
                            break;
                        }

                    }
                    rowPosition++;
                    colPosition++;
                    nextCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleMoves;
        }

        public List<int> GetAllForwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var allPossibleMoves = new List<int>();
            var results = new List<int>();
            var nextCoordinate = GetForwardRightCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };


            while (rowPosition < Max && colPosition > Min) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }
                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleMoves.Add(nextCoordinate);
                                if (enemyKing / 10 < Max && enemyKing % 10 > Max) {
                                    potentialMoves.Add(enemyKing + 9);
                                }
                            }
                            else if (numberEnemyPieceEncountered == 1) {
                                if (!coverKingMoves.ContainsKey(firstEnemyEncountered)) {
                                    coverKingMoves.Add(firstEnemyEncountered, allMovesToKing);
                                }
                            }
                            break;
                        }
                    }
                    rowPosition++;
                    colPosition--;
                    nextCoordinate = GetForwardRightCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleMoves;
        }

        public List<int> GetAllBackwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var allPossibleMoves = new List<int>();
            var results = new List<int>();
            var nextCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };


            while (rowPosition > Min && colPosition < Max) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }
                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleMoves.Add(nextCoordinate);
                                if (enemyKing / 10 > Min && enemyKing % 10 < Max) {
                                    potentialMoves.Add(enemyKing - 9);
                                }
                            }
                            else if (numberEnemyPieceEncountered == 1) {
                                if (!coverKingMoves.ContainsKey(firstEnemyEncountered)) {
                                    coverKingMoves.Add(firstEnemyEncountered, allMovesToKing);
                                }
                            }
                            break;
                        }
                    }
                    rowPosition--;
                    colPosition++;
                    nextCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleMoves;
        }

        public List<int> GetAllBackwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var allPossibleMoves = new List<int>();
            var results = new List<int>();
            var nextCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };


            while (rowPosition > Min && colPosition > Min) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }
                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleMoves.Add(nextCoordinate);
                                if (enemyKing / 10 > Min && enemyKing % 10 < Min) {
                                    potentialMoves.Add(enemyKing - 11);
                                }
                            }
                            else if (numberEnemyPieceEncountered == 1) {
                                if (!coverKingMoves.ContainsKey(firstEnemyEncountered)) {
                                    coverKingMoves.Add(firstEnemyEncountered, allMovesToKing);
                                }
                            }
                            break;
                        }
                    }
                    rowPosition--;
                    colPosition--;
                    nextCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleMoves;
        }


    }
}
