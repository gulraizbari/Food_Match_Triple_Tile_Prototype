using TripleTileMatch.Interfaces;
using UnityEngine;
using DG.Tweening;

namespace TripleTileMatch.Core
{
    public class HoldingPoint : MonoBehaviour, IHoldingPoint
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Color _normalColor;
        [SerializeField] private Color _brightColor;
        [SerializeField] private float _blinkDuration;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = gameObject.transform.localPosition;
        }

        public void StartHoldingBlockAnimation()
        {
            TriggerBlinkEffect();
            MoveWithElasticEffect();
        }

        public void TriggerBlinkEffect()
        {
            _renderer.material.DOColor(_brightColor, "_EmissionColor", _blinkDuration).OnComplete(() =>
            {
                _renderer.material.DOColor(_normalColor, "_EmissionColor", _blinkDuration);
            }).SetLoops(1);
        }

        public void MoveWithElasticEffect()
        {
            transform.DOLocalMoveZ(-0.4f, 0.075f)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    transform.DOLocalMoveZ(_startPosition.z, 0.15f)
                        .SetEase(Ease.InOutElastic)
                        .OnComplete(() => { transform.position = _startPosition; });
                });
        }
    }
}