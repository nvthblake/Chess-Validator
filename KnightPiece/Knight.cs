using ChessValidator.PiecesLibrary;
using ChessValidator.Movements;
using System;
using System.Collections.Generic;

namespace ChessValidator.KnightPiece {
    class Knight {
        private readonly IKnightMove IknightMove;
        private readonly HashSet<int> allyCoord;
        private static readonly ChessPieces chessPieces = new ChessPieces();
        private readonly int enemyKing;
        private readonly HashSet<int> protectEnemyKingMoves;
        private readonly HashSet<int> protectAllyKingMoves;
        private readonly HashSet<int> potentialMoves;

        public Knight(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            IknightMove = new KnightMove();
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
            enemyKing = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item3 : chessPieces.whiteChessPieces.Item3;
            this.protectEnemyKingMoves = protectEnemyKingMoves;
            this.protectAllyKingMoves = protectAllyKingMoves;
            this.potentialMoves = potentialMoves;
        }

        public List<int> ValidMoves(char[] piecePosition) {
            int rowPosition = Int32.Parse(piecePosition[1].ToString());
            int colPosition = Int32.Parse(piecePosition[2].ToString());
            var knightMoves = IknightMove.GetAllMoves(rowPosition, colPosition, allyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, potentialMoves);

            return knightMoves.allMove;
        }
    }
}
