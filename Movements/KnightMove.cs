using System.Collections.Generic;
using System.Linq;

namespace ChessValidator.Movements {
    internal class KnightMove : AdjacentCoordinates, IKnightMove {
        private const int Min = 1;
        private const int Max = 8;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized) {
            var allPossibleMoves = new AllKnightMoves {
                OneForwardTwoLeft = GetOneForwardTwoLeft(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneForwardTwoRight = GetOneForwardTwoRight(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneBackwardTwoLeft = GetOneBackwardTwoLeft(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneBackwardTwoRight = GetOneBackwardTwoRight(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneLeftTwoForward = GetOneLeftTwoForward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneLeftTwoBackward = GetOneLeftTwoBackward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneRightTwoForward = GetOneRightTwoForward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneRightTwoBackward = GetOneRightTwoBackward(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized)
            };
            allPossibleMoves.AllMove = new List<int> {
                allPossibleMoves.OneForwardTwoLeft,
                allPossibleMoves.OneForwardTwoRight,
                allPossibleMoves.OneBackwardTwoLeft,
                allPossibleMoves.OneBackwardTwoRight,
                allPossibleMoves.OneLeftTwoForward,
                allPossibleMoves.OneLeftTwoBackward,
                allPossibleMoves.OneRightTwoForward,
                allPossibleMoves.OneRightTwoBackward
            };
            return allPossibleMoves;
        }
        public int GetOneForwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneForwardTwoLeftCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition < Max && colPosition < Max - 1) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneForwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneForwardTwoRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition < Max && colPosition > Min + 1) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneBackwardTwoLeftCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > Min && colPosition < Max - 1) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneBackwardTwoRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > Min && colPosition > Min + 1) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneLeftTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneLeftTwoForwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition < Max - 1 && colPosition < Max) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneLeftTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneLeftTwoBackwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > Min + 1 && colPosition < Max) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneRightTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneRightTwoForwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition < Max - 1 && colPosition > Min) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneRightTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneRightTwoBackwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > Min + 1 && colPosition > Min) {
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
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }
    }
}
