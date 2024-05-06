using System.Collections.Generic;
using DG.Tweening;
using TripleTileMatch.Data;
using TripleTileMatch.Interfaces;
using UnityEngine;

namespace TripleTileMatch.Core
{
    public class MergingTray : MonoBehaviour, IMergingTray, ITripleMerge
    {
        [SerializeField] private List<HoldingPoint> _holdingPoints;
        [SerializeField] private List<Tile> _containedTiles;

        private List<Tile> _mergingObjectsList;
        private int NumberOfAvailablePoints { get; set; }
        public ITileContainer TileContainerHandler { get; set; }
        public enum MergeType
        {
            CenterMerge,
        }
        
        public List<HoldingPoint> GetHoldingPointsList()
        {
            return _holdingPoints;
        }

        public void AddToHoldingPointsList(HoldingPoint holdingPoint)
        {
            _holdingPoints.Add(holdingPoint);
        }

        public List<Tile> GetContainedTilesList()
        {
            return _containedTiles;
        }

        public void AddToContainedTilesList(Tile selectableObject)
        {
            _containedTiles.Add(selectableObject);
        }

        public void UpdateGridOnSelection(Tile currentSelectedObject)
        {
            currentSelectedObject.SetTileType( CheckAlreadyPresentTiles(currentSelectedObject));
            if (!currentSelectedObject.IsMerged)
            {
                AddToContainedTilesList(currentSelectedObject);
            }
            
            SortContainedObjects();
            CheckMerge(currentSelectedObject);
        }

        private void CheckMerge(Tile ObjectToCompare)
        {
            _mergingObjectsList.Clear();
            foreach (var item in _containedTiles)
            {
                if (item.GetTileType() == ObjectToCompare.GetTileType())
                {
                    if (_mergingObjectsList.Count < 3)
                    {
                        if (!item.IsMerged)
                        {
                            _mergingObjectsList.Add(item);
                        }
                    }
                }
            }
            
            var tempMergingList = new List<ITripleMerge>(_mergingObjectsList);

            if (_mergingObjectsList.Count == 3)
            {
                Merge(this, tempMergingList);
                DOVirtual.DelayedCall(0.5f, () =>
                {
                    // MergeVisual(tempMergingList, MergeType.CenterMerge, this);
                });
            }
            else
            {
                DOVirtual.DelayedCall(0.15f, () =>
                {
                    CheckLevelFail();
                });
            }
        }

        public void Merge(MergingTray mergingTray, List<ITripleMerge> mergeableObjects)
        {
            foreach (var item in mergeableObjects)
            {
                Tile selectable = item as Tile;
                mergingTray.NumberOfAvailablePoints++;
                selectable.IsMerged = true;
            }
        }

        private TileDataModel.TileType CheckAlreadyPresentTiles(Tile currentSelectedObject)
        {
            var lastSimilarItem = currentSelectedObject;
            foreach (var item in _containedTiles)
            {
                if (item.GetTileType() == currentSelectedObject.GetTileType()) 
                {
                    if (item.IsMerged == false)
                    {
                        lastSimilarItem = item;
                    }
                }
            }
            return lastSimilarItem.GetTileType();
        }

        private void SortContainedObjects()
        {
            NumberOfAvailablePoints = _holdingPoints.Count;
            _containedTiles.Sort(SortTilesByType); 
            
            for (int index = 0; index < _containedTiles.Count; index++)
            {
                Tile selectableObject = _containedTiles[index];
                HoldingPoint holdingPoint = _holdingPoints[index];
                selectableObject.GridPlacementAnimation(holdingPoint);
                NumberOfAvailablePoints--;
            }
            
        }

        private int SortTilesByType(Tile currentObject, Tile previousObject)
        {
            return currentObject.GetTileType().CompareTo(previousObject.GetTileType());
        }

        private void CheckLevelFail()
        {
            if (_containedTiles.Count > 4)
            {
                Debug.Log("Level Failed");
            }
        }
        
    }
}