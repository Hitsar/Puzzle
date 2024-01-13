using UnityEngine;
using TMPro;

public class LevelRewardDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text tMP;

    public void UpdateLevelRewardText(int levelReward)
    {
        tMP.text = levelReward.ToString();
    }
}
