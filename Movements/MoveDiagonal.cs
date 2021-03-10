using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class MoveDiagonal : AdjacentCoordinates, IMoveDiagonal {
        private readonly int MIN = 1;
        private readonly int MAX = 8;

        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            var allPossibleMoves = new AllOrthoDiagMoves() {
                AllForwardLeftMoves = GetAllForwardLeftMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
                AllForwardRightMoves = GetAllForwardRightMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
                AllBackwardLeftMoves = GetAllBackwardLeftMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
                AllBackwardRightMoves = GetAllBackwardRightMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves),
            };
            var mergedList = new List<int>();
            allPossibleMoves.AllForwardLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllForwardRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.allMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetAllForwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            List<int> results = new List<int>();
            int nextCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int> {originalPosition};
            while (rowPosition < MAX && colPosition < MAX) {
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
                    colPosition++;
                    nextCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition);
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

        public List<int> GetAllForwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            int nextCoordinate = GetForwardRightCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>();
            allMovesToKing.Add(originalPosition);
            while (rowPosition < MAX && colPosition > MIN) {
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
                    colPosition--;
                    nextCoordinate = GetForwardRightCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            List<int> results = new List<int>();
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

        public List<int> GetAllBackwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            int nextCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>();
            allMovesToKing.Add(originalPosition);
            while (rowPosition > MIN && colPosition < MAX) {
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
                    colPosition++;
                    nextCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            List<int> results = new List<int>();
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

        public List<int> GetAllBackwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            List<int> allPossibleMoves = new List<int>();
            int nextCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>();
            allMovesToKing.Add(originalPosition);
            while (rowPosition > MIN && colPosition > MIN) {
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
                    colPosition--;
                    nextCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition);
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                    break;
                }
            }
            List<int> results = new List<int>();
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
