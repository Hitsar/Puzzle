using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Level
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] protected int _level;
        private LevelSaver _levelSaver;
        private MoneySaver _moneySaver;
        private const string _gameplaySceneName = "GameplayScene";
        [Inject]
        public void Construct(LevelSaver levelSaver, MoneySaver moneySaver)
        {
            _levelSaver = levelSaver;
            _moneySaver = moneySaver;
        }
        public virtual void LoadLevel()
        {
            LevelNumberPasser.SetLevelNumber(_level);
            _levelSaver.Save();
            _moneySaver.SaveMoney();
            SceneManager.LoadScene(_gameplaySceneName);
        }
    }
}