using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class MoveOrthogonal : AdjacentCoordinates, IMoveOrthogonal {
        private readonly int MIN = 1;
        private readonly int MAX = 8;

        public Move GetAllMoves(int rowPostion, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            var allPossibleMoves = new AllOrthoDiagMoves() {
                AllForwardMoves = GetAllForwardMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
                AllBackwardMoves = GetAllBackwardMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
                AllLeftMoves = GetAllLeftMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
                AllRightMoves = GetAllRightMoves(rowPostion, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
            };
            var mergedList = new List<int>();
            allPossibleMoves.AllForwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.allMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetAllForwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            List<int> results = new List<int>();
            int nextCoordinate = GetForwardCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>();
            allMovesToKing.Add(originalPosition);
            while (rowPosition < MAX) {
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
            if (protectAllyKingMoves.Count != 0) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleMoves;
        }
        public List<int> GetAllBackwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            List<int> results = new List<int>();
            int nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>();
            allMovesToKing.Add(originalPosition);
            while (rowPosition > MIN) {
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
            if (protectAllyKingMoves.Count != 0) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleMoves;
        }
        public List<int> GetAllLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            List<int> results = new List<int>();
            int nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>();
            allMovesToKing.Add(originalPosition);
            while (colPosition < MAX) {
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
            if (protectAllyKingMoves.Count != 0) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                }
                return results;
            }
            return allPossibleMoves;
        }
        public List<int> GetAllRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            List<int> results = new List<int>();
            int nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>();
            allMovesToKing.Add(originalPosition);
            while (colPosition > MIN) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    if (!enemyCoord.Contains(nextCoordinate)) {
                        if (numberEnemyPieceEncountered == 0) {
                            allPossibleMoves.Add(nextCoordinate);
                            allMovesToKing.Add(nextCoordinate);
                        }
                        allMovesToKing.Add(nextCoordinate);
                    }

                    else {
                        if (nextCoordinate != enemyKing) {
                            numberEnemyPieceEncountered++;
                            if (numberEnemyPieceEncountered == 1) {
                                firstEnemyEncountered = nextCoordinate;
                                allPossibleMoves.Add(nextCoordinate);
                            }
                            else {
                                break;
                            }
                        }
                        else {
                            if (numberEnemyPieceEncountered == 0) {
                                protectEnemyKingMoves.Add(originalPosition);
                                allPossibleMoves.ForEach(item => protectEnemyKingMoves.Add(item));
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
            if (protectAllyKingMoves.Count != 0) {
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
