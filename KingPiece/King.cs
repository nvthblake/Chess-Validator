using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System.Collections.Generic;

namespace ChessValidator.KingPiece {
    internal class King {
        private readonly IKingMove _iKingMove;
        private readonly HashSet<int> _allyCoord;
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        //private HashSet<int> enemyPossibleCoordinateDictionary;
        private readonly HashSet<int> _potentialMoves;

        public King(UnitColor unitColor, HashSet<int> potentialMoves) {
            _iKingMove = new KingMove();
            _allyCoord = UnitColor.White == unitColor ? ChessPieces.WhiteChessPieces.Item2 : ChessPieces.BlackChessPieces.Item2;
            //enemyPossibleCoordinateDictionary = UnitColor.WHITE == unitColor ? allPossibleMoves.GetAllBlackPossibleCoordinates() : allPossibleMoves.GetAllWhitePossibleCoordinates();
            _potentialMoves = potentialMoves;
        }

        public List<int> GetPossibleMoves(char[] piecePosition) {
            var rowPosition = int.Parse(piecePosition[1].ToString());
            var colPosition = int.Parse(piecePosition[2].ToString());
            var kingMoves = _iKingMove.GetAllMoves(rowPosition, colPosition, _allyCoord, _potentialMoves);

            return kingMoves.AllMove;
        }
    }
}
