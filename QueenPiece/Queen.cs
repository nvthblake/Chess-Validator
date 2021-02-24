﻿using System;
using System.Collections.Generic;
using ChessValidator.Location;
using ChessValidator.Movements;

namespace ChessValidator.QueenPiece {
    class Queen {
        private IMoveOrthogonal ImoveOrthogonal;
        private IMoveDiagonal ImoveDiagonal;

        public Queen(UnitColor unitColor) {
            ImoveOrthogonal = new MoveOrthogonal();
            ImoveDiagonal = new MoveDiagonal();
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
            enemyCoord = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item2 : chessPieces.whiteChessPieces.Item2;
        }

        private readonly HashSet<int> allyCoord;
        private readonly HashSet<int> enemyCoord;

        private static readonly ChessPieces chessPieces = new ChessPieces();

        private readonly List<int> results = new List<int>();

        public List<int> ValidMoves(char[] piecePosition) {
            
            int rowPosition = Int32.Parse(piecePosition[1].ToString());
            int colPosition = Int32.Parse(piecePosition[2].ToString());

            var orthogonalMoves = ImoveOrthogonal.GetAllMoves(rowPosition, colPosition, allyCoord, enemyCoord);
            var diagonalMoves = ImoveDiagonal.GetAllMoves(rowPosition, colPosition, allyCoord, enemyCoord);
            diagonalMoves.allMove.ForEach(item => results.Add(item));
            orthogonalMoves.allMove.ForEach(item => results.Add(item));

            return results;
        }

    }
}
