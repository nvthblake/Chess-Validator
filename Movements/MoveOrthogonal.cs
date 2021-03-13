using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ChessValidator.Movements {
    [SuppressMessage("ReSharper", "ConvertIfStatementToSwitchStatement")]
    [SuppressMessage("ReSharper", "InvertIf")]
    [SuppressMessage("ReSharper", "ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator")]
    internal class MoveOrthogonal : AdjacentCoordinates, IMoveOrthogonal {
        private const int Min = 1;
        private const int Max = 8;
        private readonly List<int> _allPossibleForwardMoves;
        private readonly List<int> _allPossibleBackwardMoves;
        private readonly List<int> _allPossibleLeftMoves;
        private readonly List<int> _allPossibleRightMoves;

        public MoveOrthogonal() {
            _allPossibleForwardMoves = new List<int>();
            _allPossibleBackwardMoves = new List<int>();
            _allPossibleLeftMoves = new List<int>();
            _allPossibleRightMoves = new List<int>();
        }

        // When GetAllForwardMoves is executed, allPossibleMoves is gone. 

        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                HashSet<int> potentialMoves, bool isInitialized) {
            var allPossibleMoves = new AllOrthogonalDiagonalMoves {
                AllForwardMoves = GetAllForwardMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllBackwardMoves = GetAllBackwardMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllLeftMoves = GetAllLeftMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllRightMoves = GetAllRightMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized)
            };
            var mergedList = new List<int>();
            allPossibleMoves.AllForwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetAllForwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                            HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                            HashSet<int> potentialMoves, bool isInitialized = false) {
            var results = new List<int>();
            var nextCoordinate = GetForwardCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };


            while (rowPosition < Max) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            _allPossibleForwardMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }
                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                _allPossibleForwardMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                _allPossibleForwardMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                _allPossibleForwardMoves.Add(nextCoordinate);
                                if (enemyKing/10 < Max) {
                                    potentialMoves.Add(enemyKing + 10);
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
                    nextCoordinate = GetForwardCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (_allPossibleForwardMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return _allPossibleForwardMoves;
        }
        public List<int> GetAllBackwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                             HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                             HashSet<int> potentialMoves, bool isInitialized = false) {
            var results = new List<int>();
            var nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };


            while (rowPosition > Min) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            _allPossibleBackwardMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }

                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                _allPossibleBackwardMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                _allPossibleBackwardMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                _allPossibleBackwardMoves.Add(nextCoordinate);
                                if (enemyKing / 10 > Min) {
                                    potentialMoves.Add(enemyKing - 10);
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
                    nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (_allPossibleBackwardMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return _allPossibleBackwardMoves;
        }
        public List<int> GetAllLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                         HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                         HashSet<int> potentialMoves, bool isInitialized = false) {
            var results = new List<int>();
            var nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };


            while (colPosition < Max) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            _allPossibleLeftMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }

                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                _allPossibleLeftMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                _allPossibleLeftMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                _allPossibleLeftMoves.Add(nextCoordinate);
                                if (enemyKing % 10 < Max) {
                                    potentialMoves.Add(enemyKing + 1);
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
                    colPosition++;
                    nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (_allPossibleLeftMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return _allPossibleLeftMoves;
        }
        public List<int> GetAllRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                          HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                          HashSet<int> potentialMoves, bool isInitialized = false) {
            var results = new List<int>();
            var nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var numberEnemyPieceEncountered = 0;
            var firstEnemyEncountered = -1;
            var allMovesToKing = new List<int> { originalPosition };


            while (colPosition > Min) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            _allPossibleRightMoves.Add(nextCoordinate);
                            allMovesToKing.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }

                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                _allPossibleRightMoves.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                _allPossibleRightMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                _allPossibleRightMoves.Add(nextCoordinate);
                                if (enemyKing % 10 > Min) {
                                    potentialMoves.Add(enemyKing - 1);
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
                    colPosition--;
                    nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                foreach (var item in protectAllyKingMoves) {
                    if (_allPossibleRightMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return _allPossibleRightMoves;
        }
    }
}
