using UnityEngine;

namespace ConfigFeature
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameConfig", order = 2)]
    public class GameConfigSO : ScriptableObject
    {
        [Header("PuzzleVFX parametrs")]
        [SerializeField] private float _moveDuration;
        [SerializeField] private float _scaleDuration;
        [Tooltip("Puzzle scale will be multiplied by this number")]
        [SerializeField] private float _scaleModifier;

        public float MoveDuration => _moveDuration;
        public float ScaleDuration => _scaleDuration;
        public float ScaleModifier => _scaleModifier;
    }
}

