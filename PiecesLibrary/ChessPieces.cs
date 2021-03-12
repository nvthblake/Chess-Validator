using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessValidator.PiecesLibrary {
    internal class ChessPieces {

        public Tuple<Dictionary<int, string>, HashSet<int>, int> WhiteChessPieces;
        public Tuple<Dictionary<int, string>, HashSet<int>, int> BlackChessPieces;


        private static readonly string[] Lines = System.IO.File.ReadAllLines(@"D:\Users\nvthblake\Github\Chess-Validator\input.txt");
        public readonly string[] BlackPieces = Lines[1].Split(' ');
        public readonly string[] WhitePieces = Lines[0].Split(' ');

        public ChessPieces() {
            WhiteChessPieces = GetPieceAndLocation(WhitePieces);
            BlackChessPieces = GetPieceAndLocation(BlackPieces);
        }

        public Dictionary<int, string> GetPiecesDictionary(string[] pieces) {
            var locationDictionary = new Dictionary<int, string>();
            foreach (var item in pieces) {
                var coordinate = int.Parse(item.Substring(1));
                var piece = item.Substring(0, 1).ToLower();
                locationDictionary.Add(coordinate, piece);
            }
            return locationDictionary;
        }

        public HashSet<int> GetLocations(string[] pieces) {
            var coordinates = new HashSet<int>();
            foreach (var item in pieces) {
                var coordinate = int.Parse(item.Substring(1));
                coordinates.Add(coordinate);
            }
            return coordinates;
        }

        public int GetKingCoordinate(Dictionary<int, string> pieceDictionary) {
            return pieceDictionary.FirstOrDefault(x => x.Value == "k").Key;
        }

        private Tuple<Dictionary<int, string>, HashSet<int>, int> GetPieceAndLocation(string[] pieces) {
            var pieceDictionary = GetPiecesDictionary(pieces);
            var pieceLocation = GetLocations(pieces);
            var enemyKingLocation = GetKingCoordinate(pieceDictionary);
            return Tuple.Create(pieceDictionary, pieceLocation, enemyKingLocation);
        }
    }
}
