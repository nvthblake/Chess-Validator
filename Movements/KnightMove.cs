using System.Collections.Generic;
using System.Linq;

namespace ChessValidator.Movements {
    class KnightMove : AdjacentCoordinates, IKnightMove {
        private readonly int _min = 1;
        private readonly int _max = 8;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized) {
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

            if (rowPosition < _max && colPosition < _max - 1) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }

        public int GetOneForwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneForwardTwoRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition < _max && colPosition > _min + 1) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }

        public int GetOneBackwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneBackwardTwoLeftCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > _min && colPosition < _max - 1) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }

        public int GetOneBackwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneBackwardTwoRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > _min && colPosition > _min + 1) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }

        public int GetOneLeftTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneLeftTwoForwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition < _max - 1 && colPosition < _max) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }

        public int GetOneLeftTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneLeftTwoBackwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > _min + 1 && colPosition < _max) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }

        public int GetOneRightTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneRightTwoForwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition < _max - 1 && colPosition > _min) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }

        public int GetOneRightTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var coordinate = GetOneRightTwoBackwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            var originalPosition = rowPosition * 10 + colPosition;

            if (rowPosition > _min + 1 && colPosition > _min) {
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
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(possibleMove)) {
                    return 0;
                }
            }
            return possibleMove;
        }
    }
}
