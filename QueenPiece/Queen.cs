using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System.Collections.Generic;

namespace ChessValidator.QueenPiece {
    internal class Queen {
        private readonly IMoveOrthogonal _iMoveOrthogonal;
        private readonly IMoveDiagonal _iMoveDiagonal;
        private readonly int _enemyKing;
        private readonly HashSet<int> _protectEnemyKingMoves;
        private readonly HashSet<int> _protectAllyKingMoves;
        private readonly Dictionary<int, List<int>> _coverKingMoves;
        private readonly HashSet<int> _potentialMoves;

        public Queen(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            _iMoveOrthogonal = new MoveOrthogonal();
            _iMoveDiagonal = new MoveDiagonal();
            _allyCoord = UnitColor.White == unitColor ? ChessPieces.WhiteChessPieces.Item2 : ChessPieces.BlackChessPieces.Item2;
            _enemyCoord = UnitColor.White == unitColor ? ChessPieces.BlackChessPieces.Item2 : ChessPieces.WhiteChessPieces.Item2;
            _enemyKing = UnitColor.White == unitColor ? ChessPieces.BlackChessPieces.Item3 : ChessPieces.WhiteChessPieces.Item3;
            _protectEnemyKingMoves = protectEnemyKingMoves;
            _protectAllyKingMoves = protectAllyKingMoves;
            _coverKingMoves = coverKingMoves;
            _potentialMoves = potentialMoves;
        }

        private readonly HashSet<int> _allyCoord;
        private readonly HashSet<int> _enemyCoord;

        private static readonly ChessPieces ChessPieces = new ChessPieces();

        private readonly List<int> _results = new List<int>();

        public List<int> GetValidMoves(char[] piecePosition, bool isInitialized) {

            var rowPosition = int.Parse(piecePosition[1].ToString());
            var colPosition = int.Parse(piecePosition[2].ToString());

            var orthogonalMoves = _iMoveOrthogonal.GetAllMoves(rowPosition, colPosition, _allyCoord, _enemyCoord, _enemyKing, _protectEnemyKingMoves, _protectAllyKingMoves, _coverKingMoves, _potentialMoves, isInitialized);
            var diagonalMoves = _iMoveDiagonal.GetAllMoves(rowPosition, colPosition, _allyCoord, _enemyCoord, _enemyKing, _protectEnemyKingMoves, _protectAllyKingMoves, _coverKingMoves, _potentialMoves, isInitialized);
            diagonalMoves.AllMove.ForEach(item => _results.Add(item));
            orthogonalMoves.AllMove.ForEach(item => _results.Add(item));

            return _results;
        }

    }
}
