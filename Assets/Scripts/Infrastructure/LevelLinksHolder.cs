using Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelLinksHolder : MonoBehaviour
{
    [SerializeField] private List<PurchasedLevelButton> _levels;
    public List<PurchasedLevelButton> Levels => _levels;

    public static LevelLinksHolder Instance;
    public void Init()
    {
        if(Instance == null)
            Instance = this;
    }
}
