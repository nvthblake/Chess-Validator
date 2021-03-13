using System.Collections.Generic;

namespace ChessValidator.Movements {
    internal class KingMove : AdjacentCoordinates, IKingMove {
        private const int Min = 1;
        private const int Max = 8;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var allPossibleAdjacentMoves = new AllKingMoves {
                OneForwardMove = GetOneForwardMove(rowPosition, colPosition, allyCoord, potentialMoves),
                OneBackwardMove = GetOneBackwardMove(rowPosition, colPosition, allyCoord, potentialMoves),
                OneLeftMove = GetOneLeftMove(rowPosition, colPosition, allyCoord, potentialMoves),
                OneRightMove = GetOneRightMove(rowPosition, colPosition, allyCoord, potentialMoves),
                OneForwardLeftMove = GetOneForwardLeftMove(rowPosition, colPosition, allyCoord, potentialMoves),
                OneForwardRightMove = GetOneForwardRightMove(rowPosition, colPosition, allyCoord, potentialMoves),
                OneBackwardLeftMove = GetOneBackwardLeftMove(rowPosition, colPosition, allyCoord, potentialMoves),
                OneBackwardRightMove = GetOneBackwardRightMove(rowPosition, colPosition, allyCoord, potentialMoves)
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

        public int GetOneForwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetForwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition >= Max) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }

        public int GetOneBackwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetBackwardCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition <= Min) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }

        public int GetOneLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetLeftCoordinate(colPosition, rowPosition);
            var possibleMove = 0;
            if (colPosition >= Max) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }

        public int GetOneRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetRightCoordinate(colPosition, rowPosition);
            var possibleMove = 0;
            if (colPosition <= Min) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }

        public int GetOneForwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition >= Max || colPosition >= Max) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }

        public int GetOneForwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetForwardRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition >= Max || colPosition <= Min) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }

        public int GetOneBackwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition <= Min || colPosition >= Max) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }

        public int GetOneBackwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves) {
            var nextCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition);
            var possibleMove = 0;
            if (rowPosition <= Min || colPosition <= Min) return possibleMove;
            if (!allyCoord.Contains(nextCoordinate)) {
                possibleMove = nextCoordinate;
            }
            else {
                potentialMoves.Add(nextCoordinate);
            }
            return possibleMove;
        }
    }
}
