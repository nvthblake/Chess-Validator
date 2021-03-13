using System.Collections.Generic;
// ReSharper disable UnusedMemberInSuper.Global
// ReSharper disable UnusedMember.Global

namespace ChessValidator.Movements {
    internal interface IMovement {
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
    }

    internal interface IBasicCoordinates {
        Coordinate GetAllCoordinates(int rowPosition, int colPosition);
    }

    internal interface IKingMove {
        int GetOneForwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        int GetOneBackwardMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        int GetOneLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        int GetOneRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        int GetOneForwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        int GetOneForwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        int GetOneBackwardLeftMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        int GetOneBackwardRightMove(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> potentialMoves);
    }

    internal interface IPawnMove {
        int GetOneForwardMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, HashSet<int> protectAllyKingMoves, bool isInitialized);
        int GetTwoForwardMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, HashSet<int> protectAllyKingMoves, bool isInitialized);
        int GetOneForwardLeftMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneForwardRightMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        Move GetAllMove(UnitColor unitColor, int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
    }

    internal interface IMoveDiagonal : IMovement {
        List<int> GetAllForwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        List<int> GetAllForwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        List<int> GetAllBackwardLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        List<int> GetAllBackwardRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
    }

    internal interface IMoveOrthogonal : IMovement {
        List<int> GetAllForwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        List<int> GetAllBackwardMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        List<int> GetAllLeftMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        List<int> GetAllRightMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, HashSet<int> enemyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, Dictionary<int, List<int>> coverKingMoves, HashSet<int> potentialMoves, bool isInitialized);
    }

    internal interface IKnightMove {
        int GetOneForwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneForwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneBackwardTwoLeft(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneBackwardTwoRight(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneLeftTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneLeftTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneRightTwoForward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        int GetOneRightTwoBackward(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
        Move GetAllMoves(int rowPosition, int colPosition, HashSet<int> allyCoord, int enemyKing, HashSet<int> protectEnemyKingMoves, HashSet<int> protectAllyKingMoves, HashSet<int> potentialMoves, bool isInitialized);
    }

    internal interface IAdjacentCoordinate : IBasicCoordinates {
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