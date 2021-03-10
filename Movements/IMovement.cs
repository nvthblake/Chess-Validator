using System.Collections.Generic;

namespace ChessValidator.Movements {
    interface IMovement {
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
    }
    interface IBasicCoordinates {
        Coordinate GetAllCoordinates(int rowPosition, int colPosition);
    }
    interface IKingMove {
        int GetOneForwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneBackwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneForwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneForwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneBackwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneBackwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
    }
    interface IMoveDiagonal : IMovement {
        List<int> GetAllForwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
        List<int> GetAllForwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
        List<int> GetAllBackwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
        List<int> GetAllBackwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
    }
    interface IMoveOrthogonal : IMovement {
        List<int> GetAllForwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
        List<int> GetAllBackwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
        List<int> GetAllLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
        List<int> GetAllRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves);
    }
    interface IKnightMove {
        int GetOneForwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneForwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneBackwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneBackwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneLeftTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneLeftTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneRightTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        int GetOneRightTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves);
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