using UnityEngine;

namespace TripleTileMatch.Data
{
    public class TileDataModel
    {
        public string Name;
        public Sprite Sprite;
        public Transform Transform;
        public TileType Type;

        public enum TileType
        {
            None = 0,
            Apple = 1,
            Banana = 2,
            Carrot = 3,
        }
    }
}