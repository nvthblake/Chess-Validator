using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System.Collections.Generic;

namespace ChessValidator.KnightPiece {
    internal class Knight {
        private readonly IKnightMove _iKnightMove;
        private readonly HashSet<int> _allyCoord;
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        private readonly int _enemyKing;
        private readonly HashSet<int> _protectEnemyKingMoves;
        private readonly HashSet<int> _protectAllyKingMoves;
        private readonly HashSet<int> _potentialMoves;

        public Knight(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            _iKnightMove = new KnightMove();
            _allyCoord = UnitColor.White == unitColor ? ChessPieces.WhiteChessPieces.Item2 : ChessPieces.BlackChessPieces.Item2;
            _enemyKing = UnitColor.White == unitColor ? ChessPieces.BlackChessPieces.Item3 : ChessPieces.WhiteChessPieces.Item3;
            _protectEnemyKingMoves = protectEnemyKingMoves;
            _protectAllyKingMoves = protectAllyKingMoves;
            _potentialMoves = potentialMoves;
        }

        public List<int> GetValidMoves(char[] piecePosition, bool isInitialized) {
            var rowPosition = int.Parse(piecePosition[1].ToString());
            var colPosition = int.Parse(piecePosition[2].ToString());
            var knightMoves = _iKnightMove.GetAllMoves(rowPosition, colPosition, _allyCoord, _enemyKing, _protectEnemyKingMoves, _protectAllyKingMoves, _potentialMoves, isInitialized);

            return knightMoves.AllMove;
        }
    }
}
