using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class MoveOrthogonal : AdjacentCoordinates, IMoveOrthogonal {
        private readonly int MIN = 1;
        private readonly int MAX = 8;
        private List<int> allPossibleForwardMoves;
        private List<int> allPossibleBackwardMoves;
        private List<int> allPossibleLeftMoves;
        private List<int> allPossibleRightMoves;

        public MoveOrthogonal() {
            allPossibleForwardMoves = new List<int>();
            allPossibleBackwardMoves = new List<int>();
            allPossibleLeftMoves = new List<int>();
            allPossibleRightMoves = new List<int>();
        }

        // When GetAllForwardMoves is executed, allPossibleMoves is gone. 

        public Move GetAllMoves(int rowPostion, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                HashSet<int> potentialMoves, bool isInitialized) {
            var allPossibleMoves = new AllOrthoDiagMoves() {
                AllForwardMoves = GetAllForwardMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllBackwardMoves = GetAllBackwardMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllLeftMoves = GetAllLeftMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
                AllRightMoves = GetAllRightMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves, isInitialized),
            };
            var mergedList = new List<int>();
            allPossibleMoves.AllForwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.allMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetAllForwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                            HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                            HashSet<int> potentialMoves, bool isInitialized = false) {
            List<int> results = new List<int>();
            int nextCoordinate = GetForwardCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int> { originalPosition };


            while (rowPosition < MAX) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleForwardMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }
                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleForwardMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleForwardMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleForwardMoves.Add(nextCoordinate);
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
                    if (allPossibleForwardMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleForwardMoves;
        }
        public List<int> GetAllBackwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                             HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                             HashSet<int> potentialMoves, bool isInitialized = false) {
            List<int> results = new List<int>();
            int nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>() { originalPosition };


            while (rowPosition > MIN) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleBackwardMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }

                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleBackwardMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleBackwardMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleBackwardMoves.Add(nextCoordinate);
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
                    if (allPossibleBackwardMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleBackwardMoves;
        }
        public List<int> GetAllLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                         HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                         HashSet<int> potentialMoves, bool isInitialized = false) {
            List<int> results = new List<int>();
            int nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int> { originalPosition };


            while (colPosition < MAX) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleLeftMoves.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }

                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleLeftMoves.Add(nextCoordinate);
                                allMovesToKing.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleLeftMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleLeftMoves.Add(nextCoordinate);
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
                    if (allPossibleLeftMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleLeftMoves;
        }
        public List<int> GetAllRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing,
                                          HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves,
                                          HashSet<int> potentialMoves, bool isInitialized = false) {
            List<int> results = new List<int>();
            int nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int> { originalPosition };


            while (colPosition > MIN) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleRightMoves.Add(nextCoordinate);
                            allMovesToKing.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }

                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleRightMoves.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleRightMoves.ForEach(item => protectEnemyKingMoves.Add(item));
                                allPossibleRightMoves.Add(nextCoordinate);
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
                    if (allPossibleRightMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleRightMoves;
        }
    }
}
