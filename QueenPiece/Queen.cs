using System;
using System.Collections.Generic;
using ChessValidator.PiecesLibrary;
using ChessValidator.Movements;

namespace ChessValidator.QueenPiece {
    class Queen {
        private readonly IMoveOrthogonal ImoveOrthogonal;
        private readonly IMoveDiagonal ImoveDiagonal;
        private readonly int enemyKing;
        private readonly HashSet<int> protectEnemyKingMoves;
        private readonly HashSet<int> protectAllyKingMoves;
        private readonly Dictionary<int, List<int>> coverKingMoves;
        private readonly HashSet<int> potentialMoves;

        public Queen(UnitColor unitColor, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves) {
            ImoveOrthogonal = new MoveOrthogonal();
            ImoveDiagonal = new MoveDiagonal();
            allyCoord = UnitColor.WHITE == unitColor ? chessPieces.whiteChessPieces.Item2 : chessPieces.blackChessPieces.Item2;
            enemyCoord = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item2 : chessPieces.whiteChessPieces.Item2;
            enemyKing = UnitColor.WHITE == unitColor ? chessPieces.blackChessPieces.Item3 : chessPieces.whiteChessPieces.Item3;
            this.protectEnemyKingMoves = protectEnemyKingMoves;
            this.protectAllyKingMoves = protectAllyKingMoves;
            this.coverKingMoves = coverKingMoves;
            this.potentialMoves = potentialMoves;
        }

        private readonly HashSet<int> allyCoord;
        private readonly HashSet<int> enemyCoord;

        private static readonly ChessPieces chessPieces = new ChessPieces();

        private readonly List<int> results = new List<int>();

        public List<int> ValidMoves(char[] piecePosition) {
            
            int rowPosition = Int32.Parse(piecePosition[1].ToString());
            int colPosition = Int32.Parse(piecePosition[2].ToString());

            var orthogonalMoves = ImoveOrthogonal.GetAllMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves);
            var diagonalMoves = ImoveDiagonal.GetAllMoves(rowPosition, colPosition, allyCoord, enemyCoord, enemyKing, protectEnemyKingMoves, protectAllyKingMoves, coverKingMoves, potentialMoves);
            diagonalMoves.allMove.ForEach(item => results.Add(item));
            orthogonalMoves.allMove.ForEach(item => results.Add(item));

            return results;
        }

    }
}
