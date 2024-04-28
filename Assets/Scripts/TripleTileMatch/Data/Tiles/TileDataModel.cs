using UnityEngine;

namespace TripleTileMatch.Data
{
    public class TileDataModel : MonoBehaviour
    {
        public string Name;
        public Sprite Sprite;
        public Transform Position;

        public void Initialize(TileDataModel tileDataModel)
        {
            Name = tileDataModel.Name;
            Sprite = tileDataModel.Sprite;
            Position = tileDataModel.Position;
        }
    }
}

