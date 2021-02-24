using ChessValidator.Location;
using ChessValidator.Movements;
using System;
using System.Collections.Generic;

namespace ChessValidator.KnightPiece {
    class Knight {
        private readonly IKnightMove IknightMove;
        private readonly HashSet<int> allyCoord;
        private readonly HashSet<int> enemyCoord;
        private static readonly ChessPieces chessPieces = new ChessPieces();

        public Knight(UnitColor unitColor) {
            IknightMove = new KnightMove();
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
        }

        public List<int> ValidMoves(char[] piecePosition) {
            int rowPosition = Int32.Parse(piecePosition[1].ToString());
            int colPosition = Int32.Parse(piecePosition[2].ToString());
            var knightMoves = IknightMove.GetAllMoves(rowPosition, colPosition, allyCoord);

            return knightMoves.allMove;
        }
    }
}
