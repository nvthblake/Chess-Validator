using System.Collections.Generic;

namespace ChessValidator.Movements {
    class Coordinate {
        public List<int> AllCoordinates;
    }

    class AdjacentCoordinate : Coordinate {
        public int ForwardCoordinate { get; set; }
        public int BackwardCoordinate { get; set; }
        public int LeftCoordinate { get; set; }
        public int RightCoordinate { get; set; }
        public int ForwardLeftCoordinate { get; set; }
        public int ForwardRightCoordinate { get; set; }
        public int BackwardLeftCoordinate { get; set; }
        public int BackwardRightCoordinate { get; set; }
    }
}
