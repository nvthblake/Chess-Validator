using System.Collections.Generic;

namespace ChessValidator.Movements {
    internal class Move {
        public List<int> AllMove;
    }

    internal class AllPawnMoves : Move {
        public int OneForwardMove { get; set; }
        public int TwoForwardMove { get; set; }
        public int OneForwardLeftMove { get; set; }
        public int OneForwardRightMove { get; set; }
    }

    internal class AllKingMoves : Move {
        public int OneForwardMove { get; set; }
        public int OneBackwardMove { get; set; }
        public int OneLeftMove { get; set; }
        public int OneRightMove { get; set; }
        public int OneForwardLeftMove { get; set; }
        public int OneForwardRightMove { get; set; }
        public int OneBackwardLeftMove { get; set; }
        public int OneBackwardRightMove { get; set; }
    }

    internal class AllOrthogonalDiagonalMoves : Move {
        public List<int> AllForwardMoves { get; set; }
        public List<int> AllBackwardMoves { get; set; }
        public List<int> AllLeftMoves { get; set; }
        public List<int> AllRightMoves { get; set; }
        public List<int> AllForwardLeftMoves { get; set; }
        public List<int> AllForwardRightMoves { get; set; }
        public List<int> AllBackwardLeftMoves { get; set; }
        public List<int> AllBackwardRightMoves { get; set; }
    }

    internal class AllKnightMoves : Move {
        public int OneForwardTwoLeft { get; set; }
        public int OneForwardTwoRight { get; set; }
        public int OneBackwardTwoLeft { get; set; }
        public int OneBackwardTwoRight { get; set; }
        public int OneLeftTwoForward { get; set; }
        public int OneLeftTwoBackward { get; set; }
        public int OneRightTwoForward { get; set; }
        public int OneRightTwoBackward { get; set; }
    }
}
