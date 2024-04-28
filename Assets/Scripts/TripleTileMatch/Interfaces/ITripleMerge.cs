using System.Collections.Generic;
using UnityEngine;

namespace TripleTileMatch.Interfaces
{
    public interface ITripleMerge
    {
        public void Merge(GameObject tile, List<GameObject> holdingSlots);
    }

}
