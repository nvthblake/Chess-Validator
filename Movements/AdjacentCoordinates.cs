using System.Collections.Generic;

namespace ChessValidator.Movements {
    class AdjacentCoordinates : IAdjacentCoordinate {

        public Coordinate GetAllCoordinates(int rowPosition, int colPosition) {
            var adjacentCoordinates = new AdjacentCoordinate() {
                ForwardCoordinate = GetForwardCoordinate(rowPosition, colPosition),
                BackwardCoordinate = GetBackwardCoordinate(rowPosition, colPosition),
                RightCoordinate = GetRightCoordinate(rowPosition, colPosition),
                LeftCoordinate = GetLeftCoordinate(rowPosition, colPosition),
                ForwardLeftCoordinate = GetForwardLeftCoordinate(rowPosition, colPosition),
                ForwardRightCoordinate = GetForwardRightCoordinate(rowPosition, colPosition),
                BackwardLeftCoordinate = GetBackwardLeftCoordinate(rowPosition, colPosition),
                BackwardRightCoordinate = GetBackwardRightCoordinate(rowPosition, colPosition)

            };
            var mergedList = new List<int> {
                adjacentCoordinates.ForwardCoordinate,
                adjacentCoordinates.BackwardCoordinate,
                adjacentCoordinates.RightCoordinate,
                adjacentCoordinates.LeftCoordinate,
                adjacentCoordinates.ForwardLeftCoordinate,
                adjacentCoordinates.ForwardRightCoordinate,
                adjacentCoordinates.BackwardLeftCoordinate,
                adjacentCoordinates.BackwardRightCoordinate
            };
            adjacentCoordinates.AllCoordinates = mergedList;
            return adjacentCoordinates;
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
        public int GetForwardLeftCoordinate(int rowPosition, int colPosition) {
            return GetForwardCoordinate(rowPosition) + GetLeftCoordinate(colPosition);
        }

        public int GetForwardRightCoordinate(int rowPosition, int colPosition) {
            return GetForwardCoordinate(rowPosition) + GetRightCoordinate(colPosition);
        }
        public int GetBackwardLeftCoordinate(int rowPosition, int colPosition) {
            return GetBackwardCoordinate(rowPosition) + GetLeftCoordinate(colPosition);
        }

        public int GetBackwardRightCoordinate(int rowPosition, int colPosition) {
            return GetBackwardCoordinate(rowPosition) + GetRightCoordinate(colPosition);
        }

        public int GetOneForwardTwoLeftCoordinate(int rowPosition, int colPosition) {
            return GetForwardCoordinate(rowPosition) + GetLeftCoordinate(colPosition) + 1;
        }

        public int GetOneForwardTwoRightCoordinate(int rowPosition, int colPosition) {
            return GetForwardCoordinate(rowPosition) + GetRightCoordinate(colPosition) - 1;
        }

        public int GetOneBackwardTwoLeftCoordinate(int rowPosition, int colPosition) {
            return GetBackwardCoordinate(rowPosition) + GetLeftCoordinate(colPosition) + 1;
        }

        public int GetOneBackwardTwoRightCoordinate(int rowPosition, int colPosition) {
            return GetBackwardCoordinate(rowPosition) + GetRightCoordinate(colPosition) - 1;
        }

        public int GetOneLeftTwoForwardCoordinate(int rowPosition, int colPosition) {
            return GetLeftCoordinate(colPosition) + GetForwardCoordinate(rowPosition) + 10;
        }

        public int GetOneLeftTwoBackwardCoordinate(int rowPosition, int colPosition) {
            return GetLeftCoordinate(colPosition) + GetBackwardCoordinate(rowPosition) - 10;
        }

        public int GetOneRightTwoForwardCoordinate(int rowPosition, int colPosition) {
            return GetRightCoordinate(colPosition) + GetForwardCoordinate(rowPosition) + 10;
        }

        public int GetOneRightTwoBackwardCoordinate(int rowPosition, int colPosition) {
            return GetRightCoordinate(colPosition) + GetBackwardCoordinate(rowPosition) - 10;
        }
    }
}
