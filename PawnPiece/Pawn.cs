using System;
using System.Collections.Generic;
using ChessValidator.Location;

namespace ChessValidator.PawnPiece {
    class Pawn {
        private int row;
        private int col;

        public Pawn(UnitColor unitColor) {
            if (unitColor == UnitColor.WHITE) {
                startLine = 2;
            }
            else {
                startLine = 7;
            }
        }

        private readonly int startLine;

        private static readonly ChessPieces chessPieces = new ChessPieces();

        private readonly HashSet<int> blackCoord = chessPieces.blackChessPieces.Item2;
        private readonly HashSet<int> whiteCoord = chessPieces.whiteChessPieces.Item2;

        private readonly List<int> results = new List<int>();
        public List<int> ValidMoves(char[] piecePosition) {

            row = Int32.Parse(piecePosition[1].ToString());
            col = Int32.Parse(piecePosition[2].ToString());

            // Possible moves for pawns
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
                if (row == startLine) {
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
                if (row == startLine) {
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
