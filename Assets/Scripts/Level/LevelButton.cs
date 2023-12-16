using UnityEngine;

namespace Level
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private int _level;
        [SerializeField] private PuzzleFormat _format;

        public virtual void LoadLevel() => FindAnyObjectByType<LevelsController>().LoadLevel(_level, _format);
    }
}