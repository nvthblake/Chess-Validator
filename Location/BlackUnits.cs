using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.Location {
    class BlackUnits {
        static string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nvthblake\Desktop\Net Core\Project\ChessValidator\input.txt");
        private string[] pieces = lines[1].Split(' ');

        public Dictionary<int, string> getPiecesDictionary() {
            Dictionary<int, string> locationDictionary = new Dictionary<int, string>();
            foreach (var item in pieces) {
                int coordinate = Int32.Parse(item.Substring(1));
                string piece = item.Substring(0, 1).ToLower();
                locationDictionary.Add(coordinate, piece);
            }
            return locationDictionary;
        }
        public string[] getPieces() {
            string[] pieces = this.pieces;
            return pieces;
        }
        public HashSet<int> getLocations() {
            HashSet<int> coordinates = new HashSet<int>();
            foreach (var item in pieces) {
                int coordinate = Int32.Parse(item.Substring(1));
                coordinates.Add(coordinate);
            }
            return coordinates;
        }
    }
}
