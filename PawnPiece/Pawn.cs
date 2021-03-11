using System;
using System.Collections.Generic;
using ChessValidator.PiecesLibrary;

namespace ChessValidator.PawnPiece {
    class Pawn {
        private readonly HashSet<int> allyCoord;
        private readonly HashSet<int> enemyCoord;
        private readonly int enemyKing;
        private readonly HashSet<int> protectEnemyKingMoves;
        private readonly HashSet<int> protectAllyKingMoves;
        private readonly HashSet<int> potentialMoves;
        private readonly UnitColor unitColor;
        private readonly ChessPieces chessPieces;

        private readonly int startLine;

        public Pawn(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            chessPieces = new ChessPieces();
            startLine = UnitColor.WHITE == unitColor ? 2 : 7;
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
            enemyCoord = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item2 : chessPieces.whiteChessPieces.Item2;
            enemyKing = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item3 : chessPieces.whiteChessPieces.Item3;
            this.protectEnemyKingMoves = protectEnemyKingMoves;
            this.protectAllyKingMoves = protectAllyKingMoves;
            this.potentialMoves = potentialMoves;
            this.unitColor = unitColor;
        }


        public List<int> ValidMoves(char[] piecePosition) {

            int row = Int32.Parse(piecePosition[1].ToString());
            int col = Int32.Parse(piecePosition[2].ToString());
            

            if (row == 8 || row == 1) return new List<int>();
            return GetAllPawnMoves(row, col);
        }

        private List<int> GetAllPawnMoves(int rowPosition, int colPosition) {
            int originalPosition = rowPosition * 10 + colPosition;
            List<int> allPossibleMoves = new List<int>();
            List<int> results = new List<int>();
            int forward;
            int forwardTwo;
            int forwardRight;
            int forwardLeft;
            if (unitColor == UnitColor.WHITE) {
                // Possible moves for white pawns
                forward = (rowPosition + 1) * 10 + colPosition;
                forwardTwo = (rowPosition + 2) * 10 + colPosition;
                forwardRight = (rowPosition + 1) * 10 + (colPosition + 1);
                forwardLeft = (rowPosition + 1) * 10 + (colPosition - 1);
            }
            else {
                // Possible moves for black pawns
                forward = (rowPosition - 1) * 10 + colPosition;
                forwardTwo = (rowPosition - 2) * 10 + colPosition;
                forwardRight = (rowPosition - 1) * 10 + (colPosition + 1);
                forwardLeft = (rowPosition - 1) * 10 + (colPosition - 1);
            }
            if (!allyCoord.Contains(forward) && !enemyCoord.Contains(forward)) {
                allPossibleMoves.Add(forward);
                if (rowPosition == startLine) {
                    if (!allyCoord.Contains(forwardTwo) && !enemyCoord.Contains(forwardTwo))
                        allPossibleMoves.Add(forwardTwo);
                }
            }
            if (allyCoord.Contains(forwardRight)) {
                potentialMoves.Add(forwardRight);
            }
            if (allyCoord.Contains(forwardLeft)) {
                potentialMoves.Add(forwardLeft);
            }
            if (enemyCoord.Contains(forwardRight)) {
                if (forwardRight == enemyKing) {
                    protectEnemyKingMoves.Add(originalPosition);
                }
                allPossibleMoves.Add(forwardRight);
            }
            if (enemyCoord.Contains(forwardLeft)) {
                if (forwardLeft == enemyKing) {
                    protectEnemyKingMoves.Add(originalPosition);
                }
                allPossibleMoves.Add(forwardLeft);
            }
            if (protectAllyKingMoves.Count != 0) {
                foreach (var item in protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                    return results;
                }
            }
            return allPossibleMoves;
        }
    }
}
