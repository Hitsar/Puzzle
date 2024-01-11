using ConfigFeature;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Puzzles
{
    public class PuzzleVFX : IPuzzleVFX
    {
        private Transform _transform;
        private GameConfigSO _gameConfig;
        [Inject]
        public PuzzleVFX(GameConfigSO gameConfigSO) 
        {
            _gameConfig = gameConfigSO;
        }

        public void SetTransform(Transform transform) => _transform = transform;
        public void MoveTo(Vector2 position)
        {
            _transform.DOScale(_transform.localScale * _gameConfig.ScaleModifier, _gameConfig.ScaleDuration).SetEase(Ease.OutBack);
            _transform.DOMove(position, _gameConfig.MoveDuration).SetEase(Ease.OutBack);
        }

        public void Select()
        {
            _transform.DOScale(1, _gameConfig.ScaleDuration).SetEase(Ease.OutBack);
        }
    }
}