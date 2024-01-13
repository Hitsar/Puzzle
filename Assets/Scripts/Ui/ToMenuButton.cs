using SaveLoadSystem;
using UnityEngine;
using Zenject;

namespace UI
{ 
    public class ToMenuButton : MonoBehaviour 
    {
        private MoneySaver _moneySaver;

        [Inject]
        public void Construct(MoneySaver moneySaver)
        {
            _moneySaver = moneySaver;
        }

        public void ToMenu()
        {
            _moneySaver.SaveMoney();
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    } 
}