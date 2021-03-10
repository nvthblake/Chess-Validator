using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class ProtectKingMoves {
        public HashSet<int> ProtectWhiteKingMoves { get; set; }
        public HashSet<int> ProtectBlackKingMoves { get; set; }
        public Dictionary<int, List<int>> CoverKingMoves { get; set; }
        public HashSet<int> PotentialBlackMoves { get; set; }
        public HashSet<int> PotentialWhiteMoves { get; set; }

        public ProtectKingMoves() {
            ProtectWhiteKingMoves = new HashSet<int>();
            ProtectBlackKingMoves = new HashSet<int>();
            CoverKingMoves = new Dictionary<int, List<int>>();
            PotentialBlackMoves = new HashSet<int>();
            PotentialWhiteMoves = new HashSet<int>();
        }
    }
}
