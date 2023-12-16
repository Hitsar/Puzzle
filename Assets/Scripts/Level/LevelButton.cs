using Shop;
using UnityEngine;

namespace Level
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private int _level;
        [SerializeField] private PuzzleFormat _format;
        [SerializeField] private int _moneyForWin;

        public virtual void LoadLevel()
        {
            FindAnyObjectByType<Wallet>().SetMoneyForWin(_moneyForWin);
            FindAnyObjectByType<LevelsController>().LoadLevel(_level, _format);
        }
    }
}