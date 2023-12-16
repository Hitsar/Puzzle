using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelsController : MonoBehaviour
    {
        private static LevelsController _instance;
        public int Level { get; private set; }
        
        private void Awake()
        {
            if (_instance != null) Destroy(gameObject);
            else
            {
                DontDestroyOnLoad(gameObject);
                _instance = this;
            }
        }

        public void LoadLevel(int level, PuzzleFormat format)
        {
            Level = level;
            SceneManager.LoadScene(format.ToString());
        }
    }

    public enum PuzzleFormat
    {
        X3Y4,
        Test
    }
}