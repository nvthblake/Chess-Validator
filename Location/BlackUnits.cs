using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Location {
    class BlackUnits {
        static readonly string[] lines = System.IO.File.ReadAllLines(@"D:\Users\nvthblake\Github\Chess-Validator\input.txt");
        private readonly string[] pieces = lines[1].Split(' ');

        public Dictionary<int, string> GetPiecesDictionary() {
            Dictionary<int, string> locationDictionary = new Dictionary<int, string>();
            foreach (var item in pieces) {
                int coordinate = Int32.Parse(item.Substring(1));
                string piece = item.Substring(0, 1).ToLower();
                locationDictionary.Add(coordinate, piece);
            }
            return locationDictionary;
        }
        public string[] GetPieces() {
            string[] pieces = this.pieces;
            return pieces;
        }
        public HashSet<int> GetLocations() {
            HashSet<int> coordinates = new HashSet<int>();
            foreach (var item in pieces) {
                int coordinate = Int32.Parse(item.Substring(1));
                coordinates.Add(coordinate);
            }
            return coordinates;
        }
    }
}
