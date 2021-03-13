using System.Collections.Generic;

namespace ChessValidator.Movements {
    internal class ProtectKingMoves {
        public HashSet<int> ProtectWhiteKingMoves { get; }
        public HashSet<int> ProtectBlackKingMoves { get; }
        public Dictionary<int, List<int>> CoverKingMoves { get; }
        public HashSet<int> PotentialBlackMoves { get; }
        public HashSet<int> PotentialWhiteMoves { get; }

        public ProtectKingMoves() {
            ProtectWhiteKingMoves = new HashSet<int>();
            ProtectBlackKingMoves = new HashSet<int>();
            CoverKingMoves = new Dictionary<int, List<int>>();
            PotentialBlackMoves = new HashSet<int>();
            PotentialWhiteMoves = new HashSet<int>();
        }
    }
}
