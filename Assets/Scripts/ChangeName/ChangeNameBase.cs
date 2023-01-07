using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNameBase : MonoBehaviour
{
    [Header("References")] 
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public Player player;

    private string _playerName;

    public void ChangeName()
    {
        _playerName = uiInputField.text;
        uiTextName.text =_playerName;
        changeNameInput.SetActive(false);
        uiInputField.gameObject.SetActive(false);
        player.SetName(_playerName);
    }
}
