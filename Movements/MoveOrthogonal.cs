using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class MoveOrthogonal : AdjacentCoordinates, IMoveOrthogonal {
        private readonly int MIN = 1;
        private readonly int MAX = 8;
        public Move GetAllMoves(int rowPostion, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            var allPossibleMoves = new AllPossibleMoves() {
                AllForwardMoves = GetAllForwardMoves(rowPostion, colPosition, allyCoord, enemyCoord),
                AllBackwardMoves = GetAllBackwardMoves(rowPostion, colPosition, allyCoord, enemyCoord),
                AllLeftMoves = GetAllLeftMoves(rowPostion, colPosition, allyCoord, enemyCoord),
                AllRightMoves = GetAllRightMoves(rowPostion, colPosition, allyCoord, enemyCoord),
            };
            var mergedList = new List<int>();
            allPossibleMoves.AllForwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllBackwardMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllLeftMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.AllRightMoves.ForEach(item => mergedList.Add(item));
            allPossibleMoves.allMove = mergedList;
            return allPossibleMoves;
        }
        public List<int> GetAllForwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int forward = GetForwardCoordinate(rowPosition, colPosition);
            while (rowPosition < MAX) {
                if (!allyCoord.Contains(forward)) {
                    results.Add(forward);
                    if (!enemyCoord.Contains(forward)) {
                        rowPosition++;
                        forward = GetForwardCoordinate(rowPosition, colPosition);
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
        public List<int> GetAllBackwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int backward = GetBackwardCoordinate(rowPosition, colPosition);
            while (rowPosition > MIN) {
                if (!allyCoord.Contains(backward)) {
                    results.Add(backward);
                    if (!enemyCoord.Contains(backward)) {
                        rowPosition--;
                        backward = GetBackwardCoordinate(rowPosition, colPosition);
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
        public List<int> GetAllLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int left = GetLeftCoordinate(colPosition, rowPosition);
            while (colPosition < MAX) {
                if (!allyCoord.Contains(left)) {
                    results.Add(left);
                    if (!enemyCoord.Contains(left)) {
                        colPosition++;
                        left = GetLeftCoordinate(colPosition, rowPosition);
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
        public List<int> GetAllRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord) {
            List<int> results = new List<int>();
            int right = GetRightCoordinate(colPosition, rowPosition);
            while (colPosition > MIN) {
                if (!allyCoord.Contains(right)) {
                    results.Add(right);
                    if (!enemyCoord.Contains(right)) {
                        colPosition--;
                        right = GetRightCoordinate(colPosition, rowPosition);
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
