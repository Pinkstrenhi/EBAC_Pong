using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    private string _keyToSave = "KeyHighScore";
    [Header("References")] 
        public TextMeshProUGUI uiTextHighScore;
    #region UnityMethods
        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            UpdateText();
        }
    #endregion
    #region Save
        public void SavePlayerWin(Player player)
        {
            if (player.playerName == "")
            {
                return;
            }
            PlayerPrefs.SetString(_keyToSave, player.playerName);
            UpdateText();
        }
    #endregion
    #region Text
        private void UpdateText()
        {
            uiTextHighScore.text = PlayerPrefs.GetString(_keyToSave, "No HighScore");    
        }
    #endregion
}
