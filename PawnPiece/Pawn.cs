using System;
using System.Collections.Generic;
using ChessValidator.PiecesLibrary;

namespace ChessValidator.PawnPiece {
    class Pawn {
        private int row;
        private int col;
        private readonly HashSet<int> allyCoord;
        private readonly HashSet<int> enemyCoord;
        private readonly int enemyKing;
        private readonly HashSet<int> protectEnemyKingMoves;
        private readonly HashSet<int> protectAllyKingMoves;


        public Pawn(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves) {
            startLine = UnitColor.WHITE == unitColor ? 2 : 7;
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
            enemyCoord = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item2 : chessPieces.whiteChessPieces.Item2;
            this.protectEnemyKingMoves = protectEnemyKingMoves;
            this.protectAllyKingMoves = protectAllyKingMoves;
        }

        private readonly int startLine;

        private static readonly ChessPieces chessPieces = new ChessPieces();

        private readonly List<int> results = new List<int>();
        public List<int> ValidMoves(char[] piecePosition) {

            row = Int32.Parse(piecePosition[1].ToString());
            col = Int32.Parse(piecePosition[2].ToString());
            int originalPosition = row*10 + col;

            // Possible moves for white pawns
            int forward = (row + 1) * 10 + col;
            int forwardTwo = (row + 2) * 10 + col;
            int forwardRight = (row + 1) * 10 + (col + 1);
            int forwardLeft = (row + 1) * 10 + (col - 1);

            // Possible moves for black pawns
            int backward = (row - 1) * 10 + col;
            int backwardTwo = (row - 2) * 10 + col;
            int backwardRight = (row - 1) * 10 + (col + 1);
            int backwardLeft = (row - 1) * 10 + (col - 1);

            if (Char.IsUpper(piecePosition[0])) {
                if (row == 8 || row == 1) return new List<int>();
                if (!allyCoord.Contains(forward) && !enemyCoord.Contains(forward)) {
                    results.Add(forward);
                    if (row == startLine) {
                        if (!allyCoord.Contains(forwardTwo) && !enemyCoord.Contains(forwardTwo))
                            results.Add(forwardTwo);
                    }
                }
                if (enemyCoord.Contains(forwardRight)) {
                    if (forwardRight == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    results.Add(forwardRight);
                }
                if (enemyCoord.Contains(forwardLeft)) {
                    if (forwardLeft == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    results.Add(forwardLeft);
                }
            }
            else {
                if (row == 8 || row == 1) return new List<int>();
                if (!allyCoord.Contains(backward) && !enemyCoord.Contains(backward)) {
                    results.Add(backward);
                    if (row == startLine) {
                        if (!allyCoord.Contains(backwardTwo) && !enemyCoord.Contains(backwardTwo))
                            results.Add(backwardTwo);
                    }
                }
                if (enemyCoord.Contains(backwardRight)) {
                    if (backwardRight == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    results.Add(backwardRight);
                }
                if (enemyCoord.Contains(backwardLeft)) {
                    if (backwardLeft == enemyKing) {
                        protectEnemyKingMoves.Add(originalPosition);
                    }
                    results.Add(backwardLeft);
                }
            }
            return results;
        }
    }
}
