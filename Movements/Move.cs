using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class Move {
        public List<int> allMove;
    }
    class OneMove : Move {
        public List<int> OneForwardMove { get; set; }
        public List<int> OneBackwardMove { get; set; }
        public List<int> OneLeftMove { get; set; }
        public List<int> OneRightMove { get; set; }
        public List<int> OneForwardLeftMove { get; set; }
        public List<int> OneForwardRightMove { get; set; }
        public List<int> OneBackwardLeftMove { get; set; }
        public List<int> OneBackwardRightMove { get; set; }
    }

    class AllPossibleMoves : Move {
        public List<int> AllForwardMoves { get; set; }
        public List<int> AllBackwardMoves { get; set; }
        public List<int> AllLeftMoves { get; set; }
        public List<int> AllRightMoves { get; set; }
        public List<int> AllForwardLeftMoves { get; set; }
        public List<int> AllForwardRightMoves { get; set; }
        public List<int> AllBackwardLeftMoves { get; set; }
        public List<int> AllBackwardRightMoves { get; set; }
    }

    class AllKnightMoves : Move {
        public List<int> OneForwardTwoLeft { get; set; }
        public List<int> OneForwardTwoRight { get; set; }
        public List<int> OneBackwardTwoLeft { get; set; }
        public List<int> OneBackwardTwoRight { get; set; }
        public List<int> OneLeftTwoForward { get; set; }
        public List<int> OneLeftTwoBackward { get; set; }
        public List<int> OneRightTwoForward { get; set; }
        public List<int> OneRightTwoBackward { get; set; }
    }
}
