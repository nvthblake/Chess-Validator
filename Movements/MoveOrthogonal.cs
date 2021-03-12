﻿using System.Collections.Generic;
using System.Linq;

namespace ChessValidator.Movements {
    class MoveOrthogonal : AdjacentCoordinates, IMoveOrthogonal {
        private readonly int _min = 1;
        private readonly int _max = 8;
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
            allPossibleMoves.AllMove = mergedList;
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


            while (rowPosition < _max) {
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
            List<int> results = new List<int>();
            int nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int>() { originalPosition };


            while (rowPosition > _min) {
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
            List<int> results = new List<int>();
            int nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int> { originalPosition };


            while (colPosition < _max) {
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
            List<int> results = new List<int>();
            int nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
            int originalPosition = rowPosition * 10 + colPosition;
            int numberEnemyPieceEncountered = 0;
            int firstEnemyEncountered = -1;
            List<int> allMovesToKing = new List<int> { originalPosition };


            while (colPosition > _min) {
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