using Shop;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] protected int _level;
        [SerializeField] private int _moneyForWin;

        private const string _gameplaySceneName = "GameplayScene";
        public virtual void LoadLevel()
        {
            FindAnyObjectByType<Wallet>().SetMoneyForWin(_moneyForWin);
            LevelNumberPasser.SetLevelNumber(_level);
            SceneManager.LoadScene(_gameplaySceneName);
        }
    }
}