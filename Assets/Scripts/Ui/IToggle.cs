using UnityEngine.UI;

namespace UI
{
    public interface IToggle
    {
        Toggle Toggle { get; }
        void UpdateToggleVisuals(bool newValue);
        void UpdateLogic(Toggle change);
    }
}