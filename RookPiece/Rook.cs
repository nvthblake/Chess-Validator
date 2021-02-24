using System;
using System.Collections.Generic;
using ChessValidator.Location;
using ChessValidator.Movements;

namespace ChessValidator.RookPiece {
    class Rook {
        private readonly IMoveOrthogonal ImoveOrthogonal;
        private readonly HashSet<int> allyCoord;
        private readonly HashSet<int> enemyCoord;
        private static readonly ChessPieces chessPieces = new ChessPieces();

        public Rook(UnitColor unitColor) {
            ImoveOrthogonal = new MoveOrthogonal();
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
            enemyCoord = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item2 : chessPieces.whiteChessPieces.Item2;

        }

        public List<int> ValidMoves(char[] piecePosition) {
            int rowPosition = Int32.Parse(piecePosition[1].ToString());
            int colPosition = Int32.Parse(piecePosition[2].ToString());
            var orthogonalMoves = ImoveOrthogonal.GetAllMoves(rowPosition, colPosition, allyCoord, enemyCoord);

            return orthogonalMoves.allMove;
        }
    }
}
