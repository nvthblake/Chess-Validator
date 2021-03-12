using ChessValidator.PiecesLibrary;
using System.Collections.Generic;

namespace ChessValidator.PawnPiece {
    class Pawn {
        private readonly HashSet<int> _allyCoord;
        private readonly HashSet<int> _enemyCoord;
        private readonly int _enemyKing;
        private readonly HashSet<int> _protectEnemyKingMoves;
        private readonly HashSet<int> _protectAllyKingMoves;
        private readonly HashSet<int> _potentialMoves;
        private readonly UnitColor _unitColor;

        private readonly int _startLine;

        public Pawn(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves) {
            var chessPieces = new ChessPieces();
            _startLine = UnitColor.White == unitColor ? 2 : 7;
            _allyCoord = UnitColor.White == unitColor ? chessPieces.WhiteChessPieces.Item2 : chessPieces.BlackChessPieces.Item2;
            _enemyCoord = UnitColor.White == unitColor ? chessPieces.BlackChessPieces.Item2 : chessPieces.WhiteChessPieces.Item2;
            _enemyKing = UnitColor.White == unitColor ? chessPieces.BlackChessPieces.Item3 : chessPieces.WhiteChessPieces.Item3;
            this._protectEnemyKingMoves = protectEnemyKingMoves;
            this._protectAllyKingMoves = protectAllyKingMoves;
            this._potentialMoves = potentialMoves;
            this._unitColor = unitColor;
        }


        public List<int> GetValidMoves(char[] piecePosition) {

            var row = int.Parse(piecePosition[1].ToString());
            var col = int.Parse(piecePosition[2].ToString());


            if (row == 8 || row == 1) return new List<int>();
            return GetAllPawnMoves(row, col);
        }

        private List<int> GetAllPawnMoves(int rowPosition, int colPosition) {
            var originalPosition = rowPosition * 10 + colPosition;
            var allPossibleMoves = new List<int>();
            var results = new List<int>();
            int forward;
            int forwardTwo;
            int forwardRight;
            int forwardLeft;
            if (_unitColor == UnitColor.White) {
                // Possible moves for white pawns
                forward = (rowPosition + 1) * 10 + colPosition;
                forwardTwo = (rowPosition + 2) * 10 + colPosition;
                forwardRight = (rowPosition + 1) * 10 + (colPosition + 1);
                forwardLeft = (rowPosition + 1) * 10 + (colPosition - 1);
            }
            else {
                // Possible moves for black pawns
                forward = (rowPosition - 1) * 10 + colPosition;
                forwardTwo = (rowPosition - 2) * 10 + colPosition;
                forwardRight = (rowPosition - 1) * 10 + (colPosition + 1);
                forwardLeft = (rowPosition - 1) * 10 + (colPosition - 1);
            }
            if (!_allyCoord.Contains(forward) && !_enemyCoord.Contains(forward)) {
                allPossibleMoves.Add(forward);
                if (rowPosition == _startLine) {
                    if (!_allyCoord.Contains(forwardTwo) && !_enemyCoord.Contains(forwardTwo))
                        allPossibleMoves.Add(forwardTwo);
                }
            }
            if (_allyCoord.Contains(forwardRight)) {
                _potentialMoves.Add(forwardRight);
            }
            if (_allyCoord.Contains(forwardLeft)) {
                _potentialMoves.Add(forwardLeft);
            }
            if (_enemyCoord.Contains(forwardRight)) {
                if (forwardRight == _enemyKing) {
                    _protectEnemyKingMoves.Add(originalPosition);
                }
                allPossibleMoves.Add(forwardRight);
            }
            if (_enemyCoord.Contains(forwardLeft)) {
                if (forwardLeft == _enemyKing) {
                    _protectEnemyKingMoves.Add(originalPosition);
                }
                allPossibleMoves.Add(forwardLeft);
            }
            if (_protectAllyKingMoves.Count != 0) {
                foreach (var item in _protectAllyKingMoves) {
                    if (allPossibleMoves.Contains(item)) {
                        results.Add(item);
                    }
                    return results;
                }
            }
            return allPossibleMoves;
        }
    }
}
