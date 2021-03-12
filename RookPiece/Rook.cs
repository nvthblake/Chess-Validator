using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System.Collections.Generic;

namespace ChessValidator.RookPiece {
    class Rook {
        private readonly IMoveOrthogonal _imoveOrthogonal;
        private readonly HashSet<int> _allyCoord;
        private readonly HashSet<int> _enemyCoord;
        private static readonly ChessPieces ChessPieces = new ChessPieces();
        private readonly int _enemyKing;
        private readonly HashSet<int> _protectEnemyKingMoves;
        private readonly HashSet<int> _protectAllyKingMoves;
        private readonly Dictionary<int, List<int>> _coverKingMoves;
        private readonly HashSet<int> _potentialMoves;

        public Rook(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            _imoveOrthogonal = new MoveOrthogonal();
            _allyCoord = UnitColor.White == unitColor ? ChessPieces.WhiteChessPieces.Item2 : ChessPieces.BlackChessPieces.Item2;
            _enemyCoord = UnitColor.White == unitColor ? ChessPieces.BlackChessPieces.Item2 : ChessPieces.WhiteChessPieces.Item2;
            _enemyKing = UnitColor.White == unitColor ? ChessPieces.BlackChessPieces.Item3 : ChessPieces.WhiteChessPieces.Item3;
            this._protectEnemyKingMoves = protectEnemyKingMoves;
            this._protectAllyKingMoves = protectAllyKingMoves;
            this._coverKingMoves = coverKingMoves;
            this._potentialMoves = potentialMoves;
        }

        public List<int> GetValidMoves(char[] piecePosition, bool isInitialized) {
            var rowPosition = int.Parse(piecePosition[1].ToString());
            var colPosition = int.Parse(piecePosition[2].ToString());
            var orthogonalMoves = _imoveOrthogonal.GetAllMoves(rowPosition, colPosition, _allyCoord, _enemyCoord, _enemyKing, _protectEnemyKingMoves, _protectAllyKingMoves, _coverKingMoves, _potentialMoves, isInitialized);

            return orthogonalMoves.AllMove;
        }
    }
}
