using System.Collections.Generic;
using TripleTileMatch.Core;

namespace TripleTileMatch.Interfaces
{
    public interface ITripleMerge
    {
        public virtual void Merge(MergingTray mergingTray, List<ITripleMerge> mergeableObjects) {}
    }
}
