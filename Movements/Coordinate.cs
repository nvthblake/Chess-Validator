using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class Coordinate {
        public List<int> allCoordinates;
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
