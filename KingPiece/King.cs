using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System.Collections.Generic;

namespace ChessValidator.KingPiece {
    class King {
        private readonly IKingMove _ikingMove;
        private readonly HashSet<int> _allyCoord;
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        private readonly HashSet<int> _protectAllyKingMoves;
        //private HashSet<int> enemyPossibleCoordinateDictionary;
        private readonly HashSet<int> _potentialMoves;

        public King(UnitColor unitColor, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            _ikingMove = new KingMove();
            _allyCoord = UnitColor.White == unitColor ? ChessPieces.WhiteChessPieces.Item2 : ChessPieces.BlackChessPieces.Item2;
            //enemyPossibleCoordinateDictionary = UnitColor.WHITE == unitColor ? allPossibleMoves.GetAllBlackPossibleCoordinates() : allPossibleMoves.GetAllWhitePossibleCoordinates();
            this._protectAllyKingMoves = protectAllyKingMoves;
            this._potentialMoves = potentialMoves;
        }

        public List<int> GetPossibleMoves(char[] piecePosition) {
            var rowPosition = int.Parse(piecePosition[1].ToString());
            var colPosition = int.Parse(piecePosition[2].ToString());
            var kingMoves = _ikingMove.GetAllMoves(rowPosition, colPosition, _allyCoord, _protectAllyKingMoves, _potentialMoves);

            return kingMoves.AllMove;
        }
    }
}
