using ChessValidator.Movements;
using ChessValidator.PiecesLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ChessValidator.PawnPiece {
    class Pawn {
        private readonly IPawnMove _ipawnMove;
        private readonly HashSet<int> _allyCoord;
        private readonly HashSet<int> _enemyCoord;
        private readonly int _enemyKing;
        private readonly HashSet<int> _protectEnemyKingMoves;
        private readonly HashSet<int> _protectAllyKingMoves;
        private readonly HashSet<int> _potentialMoves;
        private readonly UnitColor _unitColor;

        public Pawn(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var chessPieces = new ChessPieces();
            _ipawnMove = new PawnMove();
            _allyCoord = UnitColor.White == unitColor ? chessPieces.WhiteChessPieces.Item2 : chessPieces.BlackChessPieces.Item2;
            _enemyCoord = UnitColor.White == unitColor ? chessPieces.BlackChessPieces.Item2 : chessPieces.WhiteChessPieces.Item2;
            _enemyKing = UnitColor.White == unitColor ? chessPieces.BlackChessPieces.Item3 : chessPieces.WhiteChessPieces.Item3;
            this._protectEnemyKingMoves = protectEnemyKingMoves;
            this._protectAllyKingMoves = protectAllyKingMoves;
            this._potentialMoves = potentialMoves;
            this._unitColor = unitColor;
        }

        public List<int> GetValidMoves(char[] piecePosition, bool isInitialized) {

            var rowPosition = int.Parse(piecePosition[1].ToString());
            var colPosition = int.Parse(piecePosition[2].ToString());
            var pawnMoves = _ipawnMove.GetAllMove(_unitColor, rowPosition, colPosition, _allyCoord, _enemyCoord, _enemyKing, _protectEnemyKingMoves, _protectAllyKingMoves, _potentialMoves, isInitialized);

            return pawnMoves.AllMove;
            //return GetAllPawnMoves(rowPosition, colPosition);
        }

        private List<int> GetAllPawnMoves(int rowPosition, int colPosition) {
            var originalPosition = rowPosition * 10 + colPosition;
            var allPossibleMoves = new List<int>();
            var results = new List<int>();

            int _startLine = _unitColor == UnitColor.White ? 2 : 7;
            var pawnForward = _unitColor == UnitColor.White ? rowPosition + 1 : rowPosition - 1;
            var pawnForwardTwo = _unitColor == UnitColor.White ? rowPosition + 2 : rowPosition - 2;
            var forward = pawnForward * 10 + colPosition;
            var forwardTwo = pawnForwardTwo * 10 + colPosition;
            var forwardRight = pawnForward * 10 + (colPosition + 1);
            var forwardLeft = pawnForward * 10 + (colPosition - 1);

            if (rowPosition == 8 || rowPosition == 1) return new List<int>();
            if (!_allyCoord.Contains(forward) && !_enemyCoord.Contains(forward)) {
                allPossibleMoves.Add(forward);
                if (rowPosition == _startLine) {
                    if (!_allyCoord.Contains(forwardTwo) && !_enemyCoord.Contains(forwardTwo))
                        allPossibleMoves.Add(forwardTwo);
                }
            }
            GetPotentialMoves(_allyCoord, _potentialMoves, forwardRight);
            GetPotentialMoves(_allyCoord, _potentialMoves, forwardLeft);
            GetPossibleMoves(rowPosition, colPosition, allPossibleMoves, _enemyCoord, _enemyKing, _protectEnemyKingMoves, forwardRight);
            GetPossibleMoves(rowPosition, colPosition, allPossibleMoves, _enemyCoord, _enemyKing, _protectEnemyKingMoves, forwardLeft);

            if (_protectAllyKingMoves.Any()) {
                foreach (var item in _protectAllyKingMoves) {
                    GetPotentialMoves(allPossibleMoves, results, item);
                    return results;
                }
            }
            return allPossibleMoves;
        }

        private void GetPossibleMoves(int rowPosition, int colPosition, List<int> allPossibleMoves, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, int coordinate) {
            var originalPosition = rowPosition * 10 + colPosition;
            if (enemyCoord.Contains(coordinate)) {
                if (coordinate == enemyKing) {
                    protectEnemyKingMoves.Add(originalPosition);
                }
                allPossibleMoves.Add(coordinate);
            }
        }
        private static void GetPotentialMoves(ICollection<int> allyCoord, ICollection<int> potentialMovesSet, int coordinate) {
            if (allyCoord.Contains(coordinate)) {
                potentialMovesSet.Add(coordinate);
            }
        }
    }
}
