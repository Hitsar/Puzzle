using UnityEngine;

namespace UI
{ 
    public class ToMenuButton : MonoBehaviour 
    { 
        public void ToMenu() => UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
    } 
}