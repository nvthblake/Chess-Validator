using System;
using System.Collections.Generic;
using ChessValidator.Location;

namespace ChessValidator.PawnPiece {
    class Pawn {
        private static readonly BlackUnits blackUnits = new BlackUnits();
        private static readonly WhiteUnits whiteUnits = new WhiteUnits();

        private readonly HashSet<int> blackCoord = blackUnits.GetLocations();
        private readonly HashSet<int> whiteCoord = whiteUnits.GetLocations();

        private readonly List<int> results = new List<int>();
        public List<int> ValidMoves(char[] piecePosition) {

            int row = Int32.Parse(piecePosition[1].ToString());
            int col = Int32.Parse(piecePosition[2].ToString());

            // Possible moves for pawns are: (R+1)*10 + C, (R+2)*10 + C, (R+1)*10 + (C+1), (R+1)*10 + (C-1)
            int forwardWht = (row + 1) * 10 + col;
            int forwardTwo = (row + 2) * 10 + col;
            int forwardRight = (row + 1) * 10 + (col + 1);
            int forwardLeft = (row + 1) * 10 + (col - 1);

            int forwardBlk = (row - 1) * 10 + col;
            int forwardTwoBlk = (row - 2) * 10 + col;
            int forwardRightBlk = (row - 1) * 10 + (col + 1);
            int forwardLeftBlk = (row - 1) * 10 + (col - 1);

            if (Char.IsUpper(piecePosition[0])) {
                if (row == 8 || row == 1) return null;
                if (row == 2) {
                    if (!blackCoord.Contains(forwardWht) && !whiteCoord.Contains(forwardWht)) {
                        if (!blackCoord.Contains(forwardTwo) && !whiteCoord.Contains(forwardTwo))
                            results.Add(forwardTwo);
                    }
                }
                if (!blackCoord.Contains(forwardWht) && !whiteCoord.Contains(forwardWht)) {
                    results.Add(forwardWht);
                }
                if (blackCoord.Contains(forwardRight)) {
                    results.Add(forwardRight);
                }
                if (blackCoord.Contains(forwardLeft)) {
                    results.Add(forwardLeft);
                }
            }
            else {
                if (row == 8 || row == 1) return null;
                if (row == 7) {
                    if (!blackCoord.Contains(forwardBlk) && !whiteCoord.Contains(forwardBlk)) {
                        if (!blackCoord.Contains(forwardTwoBlk) && !whiteCoord.Contains(forwardTwoBlk))
                            results.Add(forwardTwoBlk);
                    }
                }
                if (!blackCoord.Contains(forwardBlk) && !whiteCoord.Contains(forwardBlk)) {
                    results.Add(forwardBlk);
                }
                if (whiteCoord.Contains(forwardRightBlk)) {
                    results.Add(forwardRightBlk);
                }
                if (whiteCoord.Contains(forwardLeftBlk)) {
                    results.Add(forwardLeftBlk);
                }
            }
            return results;
        }
    }
}
