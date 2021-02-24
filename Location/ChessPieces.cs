using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Location {
    class ChessPieces {

        public Tuple<Dictionary<int, string>, HashSet<int>> whiteChessPieces;
        public Tuple<Dictionary<int, string>, HashSet<int>> blackChessPieces;


        static readonly string[] lines = System.IO.File.ReadAllLines(@"D:\Users\nvthblake\Github\Chess-Validator\input.txt");
        public readonly string[] blackPieces = lines[1].Split(' ');
        public readonly string[] whitePieces = lines[0].Split(' ');

        public ChessPieces() {
            whiteChessPieces = GetPieceAndLocation(whitePieces);
            blackChessPieces = GetPieceAndLocation(blackPieces);
        }

        public Dictionary<int, string> GetPiecesDictionary(string[] pieces) {
            Dictionary<int, string> locationDictionary = new Dictionary<int, string>();
            foreach (var item in pieces) {
                int coordinate = Int32.Parse(item.Substring(1));
                string piece = item.Substring(0, 1).ToLower();
                locationDictionary.Add(coordinate, piece);
            }
            return locationDictionary;
        }

        public HashSet<int> GetLocations(string[] pieces) {
            HashSet<int> coordinates = new HashSet<int>();
            foreach (var item in pieces) {
                int coordinate = Int32.Parse(item.Substring(1));
                coordinates.Add(coordinate);
            }
            return coordinates;
        }

        private Tuple<Dictionary<int, string>, HashSet<int>> GetPieceAndLocation(string[] pieces) {
            var pieceDictionary = GetPiecesDictionary(pieces);
            var pieceLocation = GetLocations(pieces);
            return Tuple.Create<Dictionary<int, string>, HashSet<int>>(pieceDictionary, pieceLocation);
        }
    }
}
