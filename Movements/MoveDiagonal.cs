using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class MoveDiagonal : AdjacentCoordinates, IMoveDiagonal {
        private readonly int MIN = 1;
        private readonly int MAX = 8;
        public Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            var allPossibleMoves = new AllPossibleMoves() {
                AllForwardLeftMoves = GetAllForwardLeftMoves(rowPosition, colPosition, allyCoord, enemyCoord),
                AllForwardRightMoves = GetAllForwardRightMoves(rowPosition, colPosition, allyCoord, enemyCoord),
                AllBackwardLeftMoves = GetAllBackwardLeftMoves(rowPosition, colPosition, allyCoord, enemyCoord),
                AllBackwardRightMoves = GetAllBackwardRightMoves(rowPosition, colPosition, allyCoord, enemyCoord),
            };
            var mergedList = new List<int>();
            allPossibleMoves.AllForwardLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllForwardRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.allMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetAllForwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int forwardLeft = GetForwardLeftCoordinate(rowPosition, colPosition);
            while (rowPosition < MAX && colPosition < MAX) {
                if (!allyCoord.Contains(forwardLeft)) {
                    results.Add(forwardLeft);
                    if (!enemyCoord.Contains(forwardLeft)) {
                        rowPosition++;
                        colPosition++;
                        forwardLeft = GetForwardLeftCoordinate(rowPosition, colPosition);
                    }
                    else {
                        break;
                    }
                }
                else {
                    break;
                }
            }
            return results;
        }

        public List<int> GetAllForwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int forwardRight = GetForwardRightCoordinate(rowPosition, colPosition);
            while (rowPosition < MAX && colPosition > MIN) {
                if (!allyCoord.Contains(forwardRight)) {
                    results.Add(forwardRight);
                    if (!enemyCoord.Contains(forwardRight)) {
                        rowPosition++;
                        colPosition--;
                        forwardRight = GetForwardRightCoordinate(rowPosition, colPosition);
                    }
                    else {
                        break;
                    }
                }
                else {
                    break;
                }
            }
            return results;
        }

        public List<int> GetAllBackwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int backwardLeft = GetBackwardLeftCoordinate(rowPosition, colPosition);
            while (rowPosition > MIN && colPosition < MAX) {
                if (!allyCoord.Contains(backwardLeft)) {
                    results.Add(backwardLeft);
                    if (!enemyCoord.Contains(backwardLeft)) {
                        rowPosition--;
                        colPosition++;
                        backwardLeft = GetBackwardLeftCoordinate(rowPosition, colPosition);
                    }
                    else {
                        results.Add(backwardLeft);
                        break;
                    }
                }
                else {
                    break;
                }
            }
            return results;
        }

        public List<int> GetAllBackwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int backwardRight = GetBackwardRightCoordinate(rowPosition, colPosition);
            while (rowPosition > MIN && colPosition > MIN) {
                if (!allyCoord.Contains(backwardRight)) {
                    results.Add(backwardRight);
                    if (!enemyCoord.Contains(backwardRight)) {
                        rowPosition--;
                        colPosition--;
                        backwardRight = GetBackwardRightCoordinate(rowPosition, colPosition);
                    }
                    else {
                        break;
                    }
                }
                else {
                    break;
                }
            }
            return results;
        }


    }
}
