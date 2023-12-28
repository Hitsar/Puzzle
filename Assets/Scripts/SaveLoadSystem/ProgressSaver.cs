using System;
using Shop;
using UnityEngine;

namespace Saves
{
    public class ProgressSaver : MonoBehaviour
    {
        private DateTime _lastSave;
        
        [SerializeField] private float _saveTimeInterval;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private PurchasedLevelsLoader _purchasedLevelsLoader;
        
        private void Awake()
        {
            _lastSave = DateTime.Now;
        }

        private void Update()
        {
            if (_lastSave.AddSeconds(_saveTimeInterval) >= DateTime.Now) return;
            
            Save();
            Debug.Log("Game Saved");
            _lastSave = DateTime.Now;
        }

        private void Save()
        {
            ProgressAsset saveProfile = MakeSaveAsset();
            LocalStorage.SaveProgress(saveProfile);
        }

        private ProgressAsset MakeSaveAsset()
        {
            ProgressAsset saveProfile = new ProgressAsset();
            ExportMoneyTo(saveProfile);
            ExportLevelsTo(saveProfile);
            return saveProfile;
        }

        private void ExportMoneyTo(ProgressAsset saveProfile) => saveProfile.ProgressWallet = _wallet.Export();
        
        private void ExportLevelsTo(ProgressAsset saveProfile) => saveProfile.ProgressLevels = _purchasedLevelsLoader.Export();
        
        private void OnApplicationQuit()
        {
            Save();
            Debug.Log("Game saved while closing");
        }
    }
}