using UnityEngine;
using UnityEngine.UI;

namespace TagComponents.UI
{
    public class MusicToggle : MonoBehaviour, IToggleTag
    {
        [SerializeField] private Toggle _toggle;
        public Toggle Toggle => _toggle;
    }
}

