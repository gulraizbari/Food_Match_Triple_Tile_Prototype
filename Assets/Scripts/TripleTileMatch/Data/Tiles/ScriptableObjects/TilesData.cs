using System.Collections.Generic;
using UnityEngine;

namespace TripleTileMatch.Data
{
    [CreateAssetMenu(fileName = "TilesDataList", menuName = "Core/TilesData", order = 0)]
    public class TilesData : ScriptableObject
    {
        public List<TileModel> TilesDataList;
    }
}

