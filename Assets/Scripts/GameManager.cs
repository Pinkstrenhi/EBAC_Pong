using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public static GameManager Instance;
    public float timeToSetBallFree = 1f;
    public StateMachine stateMachine;
    public List<Player> players;
    [Header("Menus")] 
        public GameObject uiMainMenu;

    #region UnityMethods
        private void Awake()
        {
            Instance = this;
        }
    #endregion

    #region Ball

        public void StartGame()
        {
            foreach (var player in players)
            {
                if (player.currentPoints > 0)
                {
                    player.currentPoints = 0;
                }
            }
            ballBase.CanMove(true);
        }

        public void EndGame()
        {
            stateMachine.SwitchStates(StateMachine.States.endGame);
        }
        
        public void ShowMainMenu()
        {
            uiMainMenu.SetActive(true);
            ballBase.CanMove(false);
        }

        public void ResetBall(bool setBallFree = true)
        {
            ballBase.CanMove(false);
            ballBase.ResetPosition();
            if (setBallFree)
            {
                Invoke(nameof(SetBallFree), timeToSetBallFree);
            }
            else
            {
                ballBase.DisableMovement();
            }
        }

        public void ResetPlayers()
        {
            foreach (var player in players)
            {
                player.ResetPlayer();
            }
        }
        private void SetBallFree()
        {
            ballBase.CanMove(true);
        }

    #endregion
}
