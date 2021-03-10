using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class KingMove : AdjacentCoordinates, IKingMove {
        private readonly int MIN = 1;
        private readonly int MAX = 8;
        private List<int> allMoves;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var allPossibleAdjacentMoves = new AllKingMoves() {
                OneForwardMove = GetOneForwardMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
                OneBackwardMove = GetOneBackwardMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
                OneLeftMove = GetOneLeftMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
                OneRightMove = GetOneRightMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
                OneForwardLeftMove = GetOneForwardLeftMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
                OneForwardRightMove = GetOneForwardRightMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
                OneBackwardLeftMove = GetOneBackwardLeftMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
                OneBackwardRightMove = GetOneBackwardRightMove(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves),
            };
            var mergedList = new List<int> {
                allPossibleAdjacentMoves.OneForwardMove,
                allPossibleAdjacentMoves.OneBackwardMove,
                allPossibleAdjacentMoves.OneLeftMove,
                allPossibleAdjacentMoves.OneRightMove,
                allPossibleAdjacentMoves.OneForwardLeftMove,
                allPossibleAdjacentMoves.OneForwardRightMove,
                allPossibleAdjacentMoves.OneBackwardLeftMove,
                allPossibleAdjacentMoves.OneBackwardRightMove
            };
            allPossibleAdjacentMoves.allMove = mergedList;
            allMoves = mergedList;
            return allPossibleAdjacentMoves;
        }

        public int GetOneForwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetForwardCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            if (rowPosition < MAX) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach(var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            if (rowPosition > MIN) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach (var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
            int possibleMove = 0;
            if (colPosition < MAX) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach (var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
            int possibleMove = 0;
            if (colPosition > MIN) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach (var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneForwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            if (rowPosition < MAX && colPosition < MAX) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach (var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneForwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetForwardRightCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            if (rowPosition < MAX && colPosition > MIN) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach (var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            if (rowPosition > MIN && colPosition < MAX) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach (var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            int nextCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition);
            int possibleMove = 0;
            if (rowPosition > MIN && colPosition > MIN) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            //foreach (var item in enemyMovesDictionary) {
            //    if (item.Value.Contains(possibleMove)) {
            //        return 0;
            //    }
            //}
            return protectAllyKingMoves.Count != 0 && protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }
    }
}
