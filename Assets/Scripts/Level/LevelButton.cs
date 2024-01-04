using Shop;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] protected int _level;
        [SerializeField] private int _moneyForWin;

        public virtual void LoadLevel()
        {
            FindAnyObjectByType<Wallet>().SetMoneyForWin(_moneyForWin);
            SceneManager.LoadScene(_level);
        }
    }
}