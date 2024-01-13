using Shop;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Level
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] protected int _level;
        [SerializeField] private int _moneyForWin;
        private LevelSaver _levelSaver;
        private const string _gameplaySceneName = "GameplayScene";
        [Inject]
        public void Construct(LevelSaver levelSaver)
        {
            _levelSaver = levelSaver;
        }
        public virtual void LoadLevel()
        {
            LevelNumberPasser.SetLevelNumber(_level);
            _levelSaver.Save();
            SceneManager.LoadScene(_gameplaySceneName);
        }
    }
}