using UnityEngine;
using UnityEngine.UI;

namespace TagComponents.UI
{
    public class SoundToggle : MonoBehaviour, IToggleTag
    {
        [SerializeField] private Toggle _toggle;
        public Toggle Toggle => _toggle;
    }
}
