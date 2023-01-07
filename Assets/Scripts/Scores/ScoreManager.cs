using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private string _keyToSaveScores = "KeyPlayerScore";
    private string _keyToSaveNames = "KeyPlayerName";
    private string playerName;
    [Header("References")] 
        public TextMeshProUGUI uiTextPlayerScore;
        public TextMeshProUGUI uiTextPlayerName;
    #region UnityMethods
    private void OnEnable()
        {
            UpdateText();
        }

    #endregion
    #region Save
    public void SavePlayerValues(Player player)
    {
        if (player.playerName == "")
        {
            return;
        }
        playerName = player.playerName;
        PlayerPrefs.SetString(_keyToSaveNames+playerName, player.playerName);
        PlayerPrefs.SetInt(_keyToSaveScores+playerName, player.saveCurrentPoints);
        UpdateText();
    }
    #endregion
    #region Text
    private void UpdateText()
    {
        uiTextPlayerScore.text = PlayerPrefs.GetInt(_keyToSaveScores+playerName,0).ToString();
        uiTextPlayerName.text = PlayerPrefs.GetString(_keyToSaveNames+playerName,"No Name");
    }
    #endregion
}
