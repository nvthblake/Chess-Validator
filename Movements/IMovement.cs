using System.Collections.Generic;

namespace ChessValidator.Movements {
    interface IMovement {
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
    }
    interface IMovementNoEnemy {
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord);
    }
    interface IBasicCoordinates {
        Coordinate GetAllCoordinates(int rowPosition, int colPosition);
    }
    interface IKingMove : IMovementNoEnemy {
        List<int> GetOneForwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneBackwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneForwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneForwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneBackwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneBackwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord);
    }
    interface IMoveDiagonal : IMovement {
        List<int> GetAllForwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
        List<int> GetAllForwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
        List<int> GetAllBackwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
        List<int> GetAllBackwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
    }
    interface IMoveOrthogonal : IMovement {
        List<int> GetAllForwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
        List<int> GetAllBackwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
        List<int> GetAllLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
        List<int> GetAllRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord);
    }
    interface IKnightMove : IMovementNoEnemy {
        List<int> GetOneForwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneForwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneBackwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneBackwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneLeftTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneLeftTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneRightTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord);
        List<int> GetOneRightTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord);
    }
    interface IAdjacentCoordinate : IBasicCoordinates {
        int GetForwardCoordinate(int rowPosition, int colPosition = 0);
        int GetBackwardCoordinate(int rowPosition, int colPosition = 0);
        int GetLeftCoordinate(int colPosition, int rowPosition = 0);
        int GetRightCoordinate(int colPosition, int rowPosition = 0);
        int GetBackwardLeftCoordinate(int rowPosition, int colPosition);
        int GetBackwardRightCoordinate(int rowPosition, int colPosition);
        int GetForwardLeftCoordinate(int rowPosition, int colPosition);
        int GetForwardRightCoordinate(int rowPosition, int colPosition);

    }
}   