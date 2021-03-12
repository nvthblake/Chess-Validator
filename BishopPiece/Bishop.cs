using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System;
using System.Collections.Generic;

namespace ChessValidator.RookPiece {
    class Bishop {
        private readonly IMoveDiagonal _imoveDiagonal;
        private readonly HashSet<int> _allyCoord;
        private readonly HashSet<int> _enemyCoord;
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        private readonly int _enemyKing;
        private readonly HashSet<int> _protectEnemyKingMoves;
        private readonly HashSet<int> _protectAllyKingMoves;
        private readonly Dictionary<int, List<int>> _coverKingMoves;
        private readonly HashSet<int> _potentialMoves;

        public Bishop(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            _imoveDiagonal = new MoveDiagonal();
            _allyCoord = UnitColor.White == unitColor ? ChessPieces.WhiteChessPieces.Item2 : ChessPieces.BlackChessPieces.Item2;
            _enemyCoord = UnitColor.White == unitColor ? ChessPieces.BlackChessPieces.Item2 : ChessPieces.WhiteChessPieces.Item2;
            _enemyKing = UnitColor.White == unitColor ? ChessPieces.BlackChessPieces.Item3 : ChessPieces.WhiteChessPieces.Item3;
            this._protectEnemyKingMoves = protectEnemyKingMoves;
            this._protectAllyKingMoves = protectAllyKingMoves;
            this._coverKingMoves = coverKingMoves;
            this._potentialMoves = potentialMoves;
        }

        public List<int> GetValidMoves(char[] piecePosition, bool isInitialized) {
            int rowPosition = Int32.Parse(piecePosition[1].ToString());
            int colPosition = Int32.Parse(piecePosition[2].ToString());
            var diagonalMoves = _imoveDiagonal.GetAllMoves(rowPosition, colPosition, _allyCoord, _enemyCoord, _enemyKing, _protectEnemyKingMoves, _protectAllyKingMoves, _coverKingMoves, _potentialMoves, isInitialized);

            return diagonalMoves.AllMove;
        }
    }
}
