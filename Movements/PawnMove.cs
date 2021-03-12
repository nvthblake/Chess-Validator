using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class PawnMove : AdjacentCoordinates, IPawnMove {
        private const int Min = 1;
        private const int Max = 8;
        public Move GetAllMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized) {
            var allPossibleMoves = new AllPawnMoves() {
                OneForwardMove = GetOneForwardMove(unitColor, rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                TwoForwardMove = GetTwoForwardMove(unitColor, rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneForwardLeftMove = GetOneForwardLeftMove(unitColor, rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
                OneForwardRightMove = GetOneForwardRightMove(unitColor, rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves, isInitialized),
            };
            allPossibleMoves.AllMove = new List<int> {
                allPossibleMoves.OneForwardMove,
                allPossibleMoves.TwoForwardMove,
                allPossibleMoves.OneForwardLeftMove,
                allPossibleMoves.OneForwardRightMove
            };
            return allPossibleMoves;
        }

        public int GetOneForwardMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var forward = unitColor == UnitColor.White ? GetForwardCoordinate(rowPosition, colPosition) : GetBackwardCoordinate(rowPosition, colPosition);

            if (rowPosition == Max || rowPosition == Min) return 0;
            if (!allyCoord.Contains(forward) && !enemyCoord.Contains(forward)) {
                return forward;
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(forward)) {
                    return 0;
                }
                return forward;
            }
            return 0;
        }
        public int GetTwoForwardMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var forward = unitColor == UnitColor.White ? GetForwardCoordinate(rowPosition, colPosition) : GetBackwardCoordinate(rowPosition, colPosition);
            var forwardTwo = unitColor == UnitColor.White ? GetForwardCoordinate(rowPosition, colPosition) + 10 : GetBackwardCoordinate(rowPosition, colPosition) - 10;
            int startLine = unitColor == UnitColor.White ? 2 : 7;

            if (rowPosition == Max || rowPosition == Min) return 0;
            if (!allyCoord.Contains(forward) && !enemyCoord.Contains(forward)) {
                if (rowPosition == startLine) {
                    if (!allyCoord.Contains(forwardTwo) && !enemyCoord.Contains(forwardTwo))
                        return forwardTwo;
                }
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(forward)) {
                    return 0;
                }
                return forward;
            }
            return 0;
        }
        public int GetOneForwardLeftMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var forwardLeft = unitColor == UnitColor.White ? GetForwardLeftCoordinate(rowPosition, colPosition) : GetBackwardLeftCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            if (enemyCoord.Contains(forwardLeft)) {
                if (forwardLeft == enemyKing) {
                    protectEnemyKingMoves.Add(originalPosition);
                }
                return forwardLeft;
            }
            if (allyCoord.Contains(forwardLeft)) {
                potentialMoves.Add(forwardLeft);
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(forwardLeft)) {
                    return 0;
                }
                return forwardLeft;
            }
            return 0;
        }
        public int GetOneForwardRightMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized = false) {
            var forwardRight = unitColor == UnitColor.White ? GetForwardRightCoordinate(rowPosition, colPosition) : GetBackwardRightCoordinate(rowPosition, colPosition);
            var originalPosition = rowPosition * 10 + colPosition;
            if (enemyCoord.Contains(forwardRight)) {
                if (forwardRight == enemyKing) {
                    protectEnemyKingMoves.Add(originalPosition);
                }
                return forwardRight;
            }
            if (allyCoord.Contains(forwardRight)) {
                potentialMoves.Add(forwardRight);
            }
            if (!isInitialized && protectAllyKingMoves.Any()) {
                if (!protectAllyKingMoves.Contains(forwardRight)) {
                    return 0;
                }
                return forwardRight;
            }
            return 0;
        }
    }
}
