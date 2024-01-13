using UnityEngine;
using TMPro;

namespace UI
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tMP;

        public void UpdateMoneyValue(int newValue)
        {
            _tMP.text = newValue.ToString();
        }
    }
}

