using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System.Collections.Generic;

namespace ChessValidator.PawnPiece {
    internal class Pawn {
        private readonly IPawnMove _iPawnMove;
        private readonly HashSet<int> _allyCoord;
        private readonly HashSet<int> _enemyCoord;
        private readonly int _enemyKing;
        private readonly HashSet<int> _protectEnemyKingMoves;
        private readonly HashSet<int> _protectAllyKingMoves;
        private readonly HashSet<int> _potentialMoves;
        private readonly UnitColor _unitColor;

        public Pawn(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var chessPieces = new ChessPieces();
            _iPawnMove = new PawnMove();
            _allyCoord = UnitColor.White == unitColor ? chessPieces.WhiteChessPieces.Item2 : chessPieces.BlackChessPieces.Item2;
            _enemyCoord = UnitColor.White == unitColor ? chessPieces.BlackChessPieces.Item2 : chessPieces.WhiteChessPieces.Item2;
            _enemyKing = UnitColor.White == unitColor ? chessPieces.BlackChessPieces.Item3 : chessPieces.WhiteChessPieces.Item3;
            _protectEnemyKingMoves = protectEnemyKingMoves;
            _protectAllyKingMoves = protectAllyKingMoves;
            _potentialMoves = potentialMoves;
            _unitColor = unitColor;
        }

        public List<int> GetValidMoves(char[] piecePosition, bool isInitialized) {

            var rowPosition = int.Parse(piecePosition[1].ToString());
            var colPosition = int.Parse(piecePosition[2].ToString());
            var pawnMoves = _iPawnMove.GetAllMove(_unitColor, rowPosition, colPosition, _allyCoord, _enemyCoord, _enemyKing, _protectEnemyKingMoves, _protectAllyKingMoves, _potentialMoves, isInitialized);

            return pawnMoves.AllMove;
        }
    }
}
