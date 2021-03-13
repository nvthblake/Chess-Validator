using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable ParameterTypeCanBeEnumerable.Local

namespace ChessValidator.PiecesLibrary {
    internal class ChessPieces {

        public readonly Tuple<Dictionary<int, string>, HashSet<int>, int> WhiteChessPieces;
        public readonly Tuple<Dictionary<int, string>, HashSet<int>, int> BlackChessPieces;
        
        public readonly string[] WhitePieces = Input.WhitePieces.Trim().Split(' ');
        public readonly string[] BlackPieces = Input.BlackPieces.Trim().Split(' ');

        public ChessPieces()
        {
            WhiteChessPieces = GetPieceAndLocation(WhitePieces);
            BlackChessPieces = GetPieceAndLocation(BlackPieces);
        }

        private static Dictionary<int, string> GetPiecesDictionary(string[] pieces) {
            var locationDictionary = new Dictionary<int, string>();
            foreach (var item in pieces) {
                var coordinate = int.Parse(item.Substring(1));
                var piece = item.Substring(0, 1).ToLower();
                locationDictionary.Add(coordinate, piece);
            }
            return locationDictionary;
        }

        private static HashSet<int> GetLocations(string[] pieces) {
            var coordinates = new HashSet<int>();
            foreach (var item in pieces) {
                var coordinate = int.Parse(item.Substring(1));
                coordinates.Add(coordinate);
            }
            return coordinates;
        }

        private static int GetKingCoordinate(Dictionary<int, string> pieceDictionary) {
            return pieceDictionary.FirstOrDefault(x => x.Value == "k").Key;
        }

        private static Tuple<Dictionary<int, string>, HashSet<int>, int> GetPieceAndLocation(string[] pieces) {
            var pieceDictionary = GetPiecesDictionary(pieces);
            var pieceLocation = GetLocations(pieces);
            var enemyKingLocation = GetKingCoordinate(pieceDictionary);
            return Tuple.Create(pieceDictionary, pieceLocation, enemyKingLocation);
        }
    }
}
