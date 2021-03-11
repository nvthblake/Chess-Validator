using ChessValidator.PiecesLibrary;
using ChessValidator.Movements;
using System;
using System.Collections.Generic;

namespace ChessValidator.KingPiece {
    class King {
        private readonly IKingMove IkingMove;
        private readonly HashSet<int> allyCoord;
        private static readonly ChessPieces chessPieces = new ChessPieces();
        private readonly HashSet<int> protectAllyKingMoves;
        //private HashSet<int> enemyPossibleCoordinateDictionary;
        private readonly HashSet<int> potentialMoves;

        public King(UnitColor unitColor, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            IkingMove = new KingMove();
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
            //enemyPossibleCoordinateDictionary = UnitColor.WHITE == unitColor ? allPossibleMoves.GetAllBlackPossibleCoordinates() : allPossibleMoves.GetAllWhitePossibleCoordinates();
            this.protectAllyKingMoves = protectAllyKingMoves;
            this.potentialMoves = potentialMoves;
        }

        public List<int> PossibleMoves(char[] piecePosition) {
            int rowPosition = Int32.Parse(piecePosition[1].ToString());
            int colPosition = Int32.Parse(piecePosition[2].ToString());
            var kingMoves = IkingMove.GetAllMoves(rowPosition, colPosition, allyCoord, protectAllyKingMoves, potentialMoves);

            return kingMoves.allMove;
        }

        //public List<int> ValidMoves(HashSet<int> enemyPossibleCoordinateDictionary) {
        //    var kingMoves = IkingMove.GetAllValidMoves(enemyPossibleCoordinateDictionary);
        //    return kingMoves;
        //}

    }
}
