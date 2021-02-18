using System;
using System.Collections.Generic;
using ChessValidator.Location;

namespace ChessValidator.QueenPiece {
    class Queen {
        private static readonly BlackUnits blackUnits = new BlackUnits();
        private static readonly WhiteUnits whiteUnits = new WhiteUnits();

        private readonly HashSet<int> blackCoord = blackUnits.GetLocations();
        private readonly HashSet<int> whiteCoord = whiteUnits.GetLocations();

        private readonly List<int> results = new List<int>();

        public List<int> ValidMoves(char[] piecePosition) {

            int row = Int32.Parse(piecePosition[1].ToString());
            int col = Int32.Parse(piecePosition[2].ToString());

            var tempRow = row;
            var tempCol = col;

            // Possible moves for pawns are: (R+1)*10 + C, (R+2)*10 + C, (R+1)*10 + (C+1), (R+1)*10 + (C-1)
            int forward = (tempRow + 1) * 10 + tempCol;
            int forwardRight = (tempRow + 1) * 10 + (tempCol - 1);
            int forwardLeft = (tempRow + 1) * 10 + (tempCol + 1);
            int backward = (tempRow - 1) * 10 + tempCol;
            int backwardRight = (tempRow - 1) * 10 + (tempCol - 1);
            int backwardLeft = (tempRow - 1) * 10 + (tempCol + 1);
            int left = tempRow * 10 + (tempCol + 1);
            int right = tempRow * 10 + (tempCol - 1);


            if (Char.IsUpper(piecePosition[0])) {
                //Forward
                while (tempRow < 8) {
                    if (!whiteCoord.Contains(forward)) {
                        if (!blackCoord.Contains(forward)) {
                            results.Add(forward);
                            tempRow++;
                            forward = (tempRow + 1) * 10 + tempCol;
                        }
                        else {
                            results.Add(forward);
                            break;
                        }
                    }
                    else {
                        break;
                    }
                }
                tempRow = row;
                tempCol = col;

                //Backward
                while (tempRow > 1) {
                    if (!whiteCoord.Contains(backward)) {
                        if (!blackCoord.Contains(backward)) {
                            results.Add(backward);
                            tempRow--;
                            backward = (tempRow - 1) * 10 + tempCol;
                        }
                        else {
                            results.Add(backward);
                            break;
                        }
                    }
                    else {
                        break;
                    }
                }
                tempRow = row;
                tempCol = col;

                //Left
                while (tempCol < 8) {
                    if (!whiteCoord.Contains(left)) {
                        if (!blackCoord.Contains(left)) {
                            results.Add(left);
                            tempCol++;
                            left = tempRow * 10 + (tempCol + 1);
                        }
                        else {
                            results.Add(left);
                            break;
                        }
                    }
                    else {
                        break;
                    }
                }
                tempRow = row;
                tempCol = col;

                //Right
                while (tempCol > 1) {
                    if (!whiteCoord.Contains(right)) {
                        if (!blackCoord.Contains(right)) {
                            results.Add(right);
                            tempCol--;
                            right = tempRow * 10 + (tempCol - 1);
                        }
                        else {
                            results.Add(right);
                            break;
                        }
                    }
                    else {
                        break;
                    }
                }
                tempRow = row;
                tempCol = col;

                //Forward Left
                while (tempRow < 8 && tempCol < 8) {
                    if (!whiteCoord.Contains(forwardLeft)) {
                        if (!blackCoord.Contains(forwardLeft)) {
                            results.Add(forwardLeft);
                            tempRow++;
                            tempCol++;
                            forwardLeft = (tempRow + 1) * 10 + (tempCol + 1);
                        }
                        else {
                            results.Add(forwardLeft);
                            break;
                        }
                    }
                    else {
                        break;
                    }
                }
                tempRow = row;
                tempCol = col;

                //Forward Right
                while (tempRow < 8 && tempCol > 1) {
                    if (!whiteCoord.Contains(forwardRight)) {
                        if (!blackCoord.Contains(forwardRight)) {
                            results.Add(forwardRight);
                            tempRow++;
                            tempCol--;
                            forwardRight = (tempRow + 1) * 10 + (tempCol - 1);
                        }
                        else {
                            results.Add(forwardRight);
                            break;
                        }
                    }
                    else {
                        break;
                    }
                }
                tempRow = row;
                tempCol = col;

                //Backward Left
                while (tempRow > 1 && tempCol < 8) {
                    if (!whiteCoord.Contains(backwardLeft)) {
                        if (!blackCoord.Contains(backwardLeft)) {
                            results.Add(backwardLeft);
                            tempRow--;
                            tempCol++;
                            backwardLeft = (tempRow - 1) * 10 + (tempCol + 1);
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
                tempRow = row;
                tempCol = col;

                //Backward Right
                while (tempRow > 1 && tempCol > 1) {
                    if (!whiteCoord.Contains(backwardRight)) {
                        if (!blackCoord.Contains(backwardRight)) {
                            results.Add(backwardRight);
                            tempRow--;
                            tempCol--;
                            backwardRight = (tempRow - 1) * 10 + (tempCol - 1);
                        }
                        else {
                            results.Add(backwardRight);
                            break;
                        }
                    }
                    else {
                        break;
                    }
                }
                tempRow = row;
                tempCol = col;
            }
            else {

            }
            return results;
        }
    }
}
