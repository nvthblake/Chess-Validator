using System.Collections.Generic;
using System.Linq;

namespace ChessValidator.Movements {
    internal class PawnMove : AdjacentCoordinates, IPawnMove {
        private const int Min = 1;
        private const int Max = 8;
        public Move GetAllMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized) {
            var allPossibleMoves = new AllPawnMoves {
                OneForwardMove = GetOneForwardMove(unitColor, rowPosition, colPosition, allyCoord, enemyCoord, protectAllyKingMoves, isInitialized),
                TwoForwardMove = GetTwoForwardMove(unitColor, rowPosition, colPosition, allyCoord, enemyCoord, protectAllyKingMoves, isInitialized),
                OneForwardLeftMove = GetOneForwardLeftMove(unitColor, rowPosition, colPosition, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneForwardRightMove = GetOneForwardRightMove(unitColor, rowPosition, colPosition, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized)
            };
            allPossibleMoves.AllMove = new List<int> {
                allPossibleMoves.OneForwardMove,
                allPossibleMoves.TwoForwardMove,
                allPossibleMoves.OneForwardLeftMove,
                allPossibleMoves.OneForwardRightMove
            };
            return allPossibleMoves;
        }

        public int GetOneForwardMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, HashSet<int> protectAllyKingMoves, bool isInitialized = false) {
            var forward = unitColor == UnitColor.White ? GetForwardCoordinate(rowPosition, colPosition) : GetBackwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition == Max || rowPosition == Min) return 0;
            if (!allyCoord.Contains(forward) && !enemyCoord.Contains(forward)) {
                possibleMove = forward;
            }

            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(forward) ? 0 : possibleMove;
        }
        public int GetTwoForwardMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, HashSet<int> protectAllyKingMoves, bool isInitialized = false) {
            var forward = unitColor == UnitColor.White ? GetForwardCoordinate(rowPosition, colPosition) : GetBackwardCoordinate(rowPosition, colPosition);
            var forwardTwo = unitColor == UnitColor.White ? GetForwardCoordinate(rowPosition, colPosition) + 10 : GetBackwardCoordinate(rowPosition, colPosition) - 10;
            var startLine = unitColor == UnitColor.White ? 2 : 7;
            var possibleMove = 0;
            if (rowPosition == Max || rowPosition == Min) return 0;
            if (!allyCoord.Contains(forward) && !enemyCoord.Contains(forward)) {
                if (rowPosition == startLine) {
                    if (!allyCoord.Contains(forwardTwo) && !enemyCoord.Contains(forwardTwo))
                        possibleMove = forwardTwo;
                }
            }

            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(forwardTwo) ? 0 : possibleMove;
        }
        public int GetOneForwardLeftMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var forwardLeft = unitColor == UnitColor.White ? GetForwardLeftCoordinate(rowPosition, colPosition) : GetBackwardLeftCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var possibleMove = 0;
            if (enemyCoord.Contains(forwardLeft)) {
                if (forwardLeft == enemyKing) {
                    protectEnemyKingMoves.Add(originalPosition);
                }
                possibleMove = forwardLeft;
            }
            //if (allyCoord.Contains(forwardLeft)) {
            //    potentialMoves.Add(forwardLeft);
            //}
            potentialMoves.Add(forwardLeft);
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(forwardLeft) ? 0 : possibleMove;
        }
        public int GetOneForwardRightMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var forwardRight = unitColor == UnitColor.White ? GetForwardRightCoordinate(rowPosition, colPosition) : GetBackwardRightCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            var possibleMove = 0;
            if (enemyCoord.Contains(forwardRight)) {
                if (forwardRight == enemyKing) {
                    protectEnemyKingMoves.Add(originalPosition);
                }
                possibleMove = forwardRight;
            }
            //if (allyCoord.Contains(forwardRight)) {
            //    potentialMoves.Add(forwardRight);
            //}
            potentialMoves.Add(forwardRight);
            if (isInitialized || !protectAllyKingMoves.Any()) return possibleMove;
            return !protectAllyKingMoves.Contains(forwardRight) ? 0 : possibleMove;
        }
    }
}
