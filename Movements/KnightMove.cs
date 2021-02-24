using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class KnightMove : AdjacentCoordinates, IKnightMove {
        private readonly int MIN = 1;
        private readonly int MAX = 8;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            var allPossibleMoves = new AllKnightMoves() {
                OneForwardTwoLeft = GetOneForwardTwoLeft(rowPosition, colPosition, allyCoord),
                OneForwardTwoRight = GetOneForwardTwoRight(rowPosition, colPosition, allyCoord),
                OneBackwardTwoLeft = GetOneBackwardTwoLeft(rowPosition, colPosition, allyCoord),
                OneBackwardTwoRight = GetOneBackwardTwoRight(rowPosition, colPosition, allyCoord),
                OneLeftTwoForward = GetOneLeftTwoForward(rowPosition, colPosition, allyCoord),
                OneLeftTwoBackward = GetOneLeftTwoBackward(rowPosition, colPosition, allyCoord),
                OneRightTwoForward = GetOneRightTwoForward(rowPosition, colPosition, allyCoord),
                OneRightTwoBackward = GetOneRightTwoBackward(rowPosition, colPosition, allyCoord)
            };
            var mergedList = new List<int>();
            allPossibleMoves.OneForwardTwoLeft.ForEach(item => mergedList.Add(item));
            allPossibleMoves.OneForwardTwoRight.ForEach(item => mergedList.Add(item));
            allPossibleMoves.OneBackwardTwoLeft.ForEach(item => mergedList.Add(item));
            allPossibleMoves.OneBackwardTwoRight.ForEach(item => mergedList.Add(item));
            allPossibleMoves.OneLeftTwoForward.ForEach(item => mergedList.Add(item));
            allPossibleMoves.OneLeftTwoBackward.ForEach(item => mergedList.Add(item));
            allPossibleMoves.OneRightTwoForward.ForEach(item => mergedList.Add(item));
            allPossibleMoves.OneRightTwoBackward.ForEach(item => mergedList.Add(item));
            allPossibleMoves.allMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetOneForwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneForwardTwoLeftCoordinate(rowPosition, colPosition);
            if (rowPosition < MAX && colPosition < MAX - 1) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }

        public List<int> GetOneForwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneForwardTwoRightCoordinate(rowPosition, colPosition);
            if (rowPosition < MAX && colPosition > MIN + 1) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }

        public List<int> GetOneBackwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneBackwardTwoLeftCoordinate(rowPosition, colPosition);
            if (rowPosition > MIN && colPosition < MAX - 1) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }

        public List<int> GetOneBackwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneBackwardTwoRightCoordinate(rowPosition, colPosition);
            if (rowPosition > MIN && colPosition > MIN + 1) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }

        public List<int> GetOneLeftTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneLeftTwoForwardCoordinate(rowPosition, colPosition);
            if (rowPosition < MAX - 1 && colPosition < MAX) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }

        public List<int> GetOneLeftTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneLeftTwoBackwardCoordinate(rowPosition, colPosition);
            if (rowPosition > MIN + 1 && colPosition < MAX) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }

        public List<int> GetOneRightTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneRightTwoForwardCoordinate(rowPosition, colPosition);
            if (rowPosition < MAX - 1 && colPosition > MIN) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }

        public List<int> GetOneRightTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord) {
            List<int> result = new List<int>();
            int coordinate = GetOneRightTwoBackwardCoordinate(rowPosition, colPosition);
            if (rowPosition > MIN + 1 && colPosition > MIN) {
                if (!allyCoord.Contains(coordinate)) {
                    result.Add(coordinate);
                }
            }
            return result;
        }
    }
}
