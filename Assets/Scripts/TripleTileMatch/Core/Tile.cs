using DG.Tweening;
using TripleTileMatch.Controllers;
using TripleTileMatch.Data;
using TripleTileMatch.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TripleTileMatch.Core
{
    public class Tile : MonoBehaviour, ITile, ITripleMerge, IPointerDownHandler
    {
        private Tween _tween;
        private TileDataModel _tileDataModel;
        private TilesContainer _tilesContainer;
        
        public bool IsMerged { get; set; }

        public void SetTileContainer(TilesContainer tilesContainer)
        {
            _tilesContainer = tilesContainer;
        }

        public string GetName()
        {
            return _tileDataModel.Name;
        }

        public Sprite GetSprite()
        {
            return _tileDataModel.Sprite;
        }

        public Transform GetTransform()
        {
            return _tileDataModel.Transform;
        }

        public TileDataModel.TileType GetTileType()
        {
            return _tileDataModel.Type;
        }

        public void SetTileType(TileDataModel.TileType tileType)
        {
            _tileDataModel.Type = tileType;
        }

        public void Initialize(TileDataModel tileDataModel)
        {
            _tileDataModel = tileDataModel;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var tileObjectName = GetName();
            var tileObjectIndex = _tilesContainer.GetIndexOfTile(tileObjectName);
            Debug.Log("Selected Tile Index: " + tileObjectIndex);
            _tilesContainer.UpdateMergingListOnTileSelection(this);
            _tilesContainer.RemoveTileAtIndex(tileObjectIndex);
        }

        public void GridPlacementAnimation(HoldingPoint holdingPoint)
        {
            var destinationPoint = holdingPoint.transform.position;
            var positionY = transform.position.y * 3;
            var localScale = transform.localScale;

            transform.DOScale(localScale * 2, 0.15f);
            transform.DOLocalRotate(Vector3.zero, 0.13f);
            _tween = transform.DOMoveX(destinationPoint.x, 0.13f);
            transform.DOMoveY(positionY, 0.15f).OnComplete(() =>
            {
                _tween.Kill();
                transform.DOMove(destinationPoint, 0.1f).OnComplete(() =>
                {
                    transform.localPosition = Vector3.zero;
                    holdingPoint.StartHoldingBlockAnimation();
                });
                transform.DOScale(Vector3.one, 0.1f);
            });
        }
        
    }
}