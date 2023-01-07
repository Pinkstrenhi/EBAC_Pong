using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    
    public int maxPoints = 3;
    public float speed = 10f;
    public string playerName;
    public int saveCurrentPoints;
    [Header("References")]
    public Image uiPlayer;
    public ScoreManager scoreManager;
    [Header("Key Setup")] 
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;
    public Rigidbody2D myRigidbody2D;
    [Header("Points")] public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    #region UnityMethods

    private void Awake()
    {
        ResetPlayer();
    }

    private void Update()
    {
        PaddleMovement();
        ResetGame();
    }

    #endregion

    #region Reset

    public void ResetPlayer()
    {
        UpdateUI();
    }

    private void ResetGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StateMachine.Instance.ResetPosition();
            ResetPlayer();
        }
    }

    #endregion

    #region Points

    public void AddPoints()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        saveCurrentPoints = currentPoints;
        scoreManager.SavePlayerValues(this);
    }

    private void UpdateUI()
    {
        if (playerName == "")
        {
            return;
        }
        uiTextPoints.text = playerName + ": " + currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if (currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SavePlayerWin(this);
        }
    }

    #endregion

    #region Paddle

    private void PaddleMovement()
    {
        if (Input.GetKey(keyCodeMoveUp))
        {
            myRigidbody2D.MovePosition
                (transform.position + transform.up * speed);
        }
        else if (Input.GetKey(keyCodeMoveDown))
        {
            myRigidbody2D.MovePosition
                (transform.position + transform.up * -speed);
        }
    }

    #endregion

    #region PlayerActions

    public void ChangeColor(Color playerColor)
    {
        uiPlayer.color = playerColor;
    }

    public void SetName(string nameThePlayer)
    {
        playerName = nameThePlayer;
    }
    #endregion
    
}
