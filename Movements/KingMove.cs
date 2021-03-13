using System.Collections.Generic;

namespace ChessValidator.Movements {
    class KingMove : AdjacentCoordinates, IKingMove {
        private const int Min = 1;
        private const int Max = 8;
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
            allPossibleAdjacentMoves.AllMove = mergedList;
            return allPossibleAdjacentMoves;
        }

        public int GetOneForwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetForwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition < Max) {
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
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition > Min) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
            var possibleMove = 0;
            if (colPosition < Max) {
                if (!allyCoord.Contains(nextCoordinate)) {
                    possibleMove = nextCoordinate;
                }
                else {
                    potentialMoves.Add(nextCoordinate);
                }
            }
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
            var possibleMove = 0;
            if (colPosition > Min) {
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
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneForwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition < Max && colPosition < Max) {
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
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneForwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetForwardRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition < Max && colPosition > Min) {
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
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition > Min && colPosition < Max) {
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
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }

        public int GetOneBackwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var nextCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition > Min && colPosition > Min) {
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
            return protectAllyKingMoves.Count != 0 && !protectAllyKingMoves.Contains(possibleMove) ? 0 : possibleMove;
        }
    }
}
