using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Movements {
    class AdjacentOrthogonalCoordinates : IAdjacentOrthogonalCoordinate {

        public Coordinate GetAllCoordinates(int rowPosition, int colPosition) {
            var orthogonalCoordinate = new AdjacentCoordinates() {
                ForwardCoordinate = GetForwardCoordinate(rowPosition, colPosition),
                BackwardCoordinate = GetBackwardCoordinate(rowPosition, colPosition),
                LeftCoordinate = GetLeftCoordinate(colPosition, rowPosition),
                RightCoordinate = GetRightCoordinate(colPosition, rowPosition),
            };
            var mergedList = new List<int> {
                orthogonalCoordinate.ForwardCoordinate,
                orthogonalCoordinate.BackwardCoordinate,
                orthogonalCoordinate.LeftCoordinate,
                orthogonalCoordinate.RightCoordinate
            };
            orthogonalCoordinate.allCoordinates = mergedList;
            return orthogonalCoordinate;
        }
        public int GetForwardCoordinate(int rowPosition, int colPosition = 0) {
            return (rowPosition + 1) * 10 + colPosition;
        }

        public int GetBackwardCoordinate(int rowPosition, int colPosition = 0) {
            return (rowPosition - 1) * 10 + colPosition;
        }

        public int GetLeftCoordinate(int colPosition, int rowPosition = 0) {
            return rowPosition * 10 + (colPosition + 1);
        }

        public int GetRightCoordinate(int colPosition, int rowPosition = 0) {
            return rowPosition * 10 + (colPosition - 1);
        }
    }
}
