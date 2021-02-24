using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class KingMove : AdjacentCoordinates, IKingMove {
        private readonly int MIN = 1;
        private readonly int MAX = 8;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            var allPossibleAdjacentMoves = new OneMove() {
                OneForwardMove = GetOneForwardMove(rowPosition, colPosition, allyCoord),
                OneBackwardMove = GetOneBackwardMove(rowPosition, colPosition, allyCoord),
                OneLeftMove = GetOneLeftMove(rowPosition, colPosition, allyCoord),
                OneRightMove = GetOneRightMove(rowPosition, colPosition, allyCoord),
                OneForwardLeftMove = GetOneForwardLeftMove(rowPosition, colPosition, allyCoord),
                OneForwardRightMove = GetOneForwardRightMove(rowPosition, colPosition, allyCoord),
                OneBackwardLeftMove = GetOneBackwardLeftMove(rowPosition, colPosition, allyCoord),
                OneBackwardRightMove = GetOneBackwardRightMove(rowPosition, colPosition, allyCoord),
            };
            var mergedList = new List<int>();
            allPossibleAdjacentMoves.OneForwardMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.OneBackwardMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.OneLeftMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.OneRightMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.OneForwardLeftMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.OneForwardRightMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.OneBackwardLeftMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.OneBackwardRightMove.ForEach(item => mergedList.Add(item));
            allPossibleAdjacentMoves.allMove = mergedList;
            return allPossibleAdjacentMoves;
        }

        public List<int> GetOneForwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int forward = GetForwardCoordinate(rowPosition, colPosition);
            if (rowPosition < MAX) {
                if (!allyCoord.Contains(forward)) {
                    result.Add(forward);
                }
            }
            return result;
        }

        public List<int> GetOneBackwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int backward = GetBackwardCoordinate(rowPosition, colPosition);
            if (rowPosition > MIN) {
                if (!allyCoord.Contains(backward)) {
                    result.Add(backward);
                }
            }
            return result;
        }

        public List<int> GetOneLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int left = GetLeftCoordinate(colPosition, rowPosition);
            if (colPosition < MAX) {
                if (!allyCoord.Contains(left)) {
                    result.Add(left);
                }
            }
            return result;
        }

        public List<int> GetOneRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int right = GetRightCoordinate(colPosition, rowPosition);
            if (colPosition > MIN) {
                if (!allyCoord.Contains(right)) {
                    result.Add(right);
                }
            }
            return result;
        }

        public List<int> GetOneForwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> results = new List<int>();
            int forwardLeft = GetForwardLeftCoordinate(rowPosition, colPosition);
            if (rowPosition < MAX && colPosition < MAX) {
                if (!allyCoord.Contains(forwardLeft)) {
                    results.Add(forwardLeft);
                }
            }
            return results;
        }

        public List<int> GetOneForwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> results = new List<int>();
            int forwardRight = GetForwardRightCoordinate(rowPosition, colPosition);
            if (rowPosition < MAX && colPosition > MIN) {
                if (!allyCoord.Contains(forwardRight)) {
                    results.Add(forwardRight);
                }
            }
            return results;
        }

        public List<int> GetOneBackwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> results = new List<int>();
            int backwardLeft = GetBackwardLeftCoordinate(rowPosition, colPosition);
            if (rowPosition > MIN && colPosition < MAX) {
                if (!allyCoord.Contains(backwardLeft)) {
                    results.Add(backwardLeft);
                }
            }
            return results;
        }

        public List<int> GetOneBackwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> results = new List<int>();
            int backwardRight = GetBackwardRightCoordinate(rowPosition, colPosition);
            if (rowPosition > MIN && colPosition > MIN) {
                if (!allyCoord.Contains(backwardRight)) {
                    results.Add(backwardRight);
                }
            }
            return results;
        }
    }
}
