using SaveLoadSystem;
using System;
using UnityEngine;
using Zenject;

public class SaveTimer : MonoBehaviour
{
    [SerializeField] private float _saveTimeInterval;
    private DateTime _lastSave;
    private MoneySaver _moneySaver;
    private LevelSaver _levelSaver;

    [Inject]
    public void Construct(MoneySaver moneySaver, LevelSaver levelSaver)
    {
        _moneySaver = moneySaver;
        _levelSaver = levelSaver;
    }

    private void Awake()
    {
        _lastSave = DateTime.Now;
    }

    private void Update()
    {
        if (_lastSave.AddSeconds(_saveTimeInterval) >= DateTime.Now) return;

        _moneySaver.SaveMoney();
        _levelSaver.Save();
        _lastSave = DateTime.Now;
    }

    private void OnApplicationQuit()
    {
        _moneySaver.SaveMoney();
        _levelSaver.Save();
        Debug.Log("Game saved while closing");
    }
}
