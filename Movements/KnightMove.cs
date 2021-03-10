using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class KnightMove : AdjacentCoordinates, IKnightMove {
        private readonly int MIN = 1;
        private readonly int MAX = 8;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var allPossibleMoves = new AllKnightMoves() {
                OneForwardTwoLeft = GetOneForwardTwoLeft(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves),
                OneForwardTwoRight = GetOneForwardTwoRight(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves),
                OneBackwardTwoLeft = GetOneBackwardTwoLeft(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves),
                OneBackwardTwoRight = GetOneBackwardTwoRight(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves),
                OneLeftTwoForward = GetOneLeftTwoForward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves),
                OneLeftTwoBackward = GetOneLeftTwoBackward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves),
                OneRightTwoForward = GetOneRightTwoForward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves),
                OneRightTwoBackward = GetOneRightTwoBackward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves)
            };
            var mergedList = new List<int> {
                allPossibleMoves.OneForwardTwoLeft,
                allPossibleMoves.OneForwardTwoRight,
                allPossibleMoves.OneBackwardTwoLeft,
                allPossibleMoves.OneBackwardTwoRight,
                allPossibleMoves.OneLeftTwoForward,
                allPossibleMoves.OneLeftTwoBackward,
                allPossibleMoves.OneRightTwoForward,
                allPossibleMoves.OneRightTwoBackward
            };
            allPossibleMoves.allMove = mergedList;
            return allPossibleMoves;
        }
        public int GetOneForwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneForwardTwoLeftCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition < MAX && colPosition < MAX - 1) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneForwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneForwardTwoRightCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition < MAX && colPosition > MIN + 1) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneBackwardTwoLeftCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition > MIN && colPosition < MAX - 1) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneBackwardTwoRightCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition > MIN && colPosition > MIN + 1) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneLeftTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneLeftTwoForwardCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition < MAX - 1 && colPosition < MAX) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneLeftTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneLeftTwoBackwardCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition > MIN + 1 && colPosition < MAX) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneRightTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneRightTwoForwardCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition < MAX - 1 && colPosition > MIN) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneRightTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int coordinate = GetOneRightTwoBackwardCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            int originalPosition = rowPosition * 10 + colPosition;
            if (rowPosition > MIN + 1 && colPosition > MIN) {
                if (!allyCoord.Contains(coordinate)) {
                    if (coordinate == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    possibleMove = coordinate;
                }
                else {
                    potentialMoves.Add(coordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }
    }
}
