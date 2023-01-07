using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTrigger : MonoBehaviour
{
    public Player player;
    public string checkBallTag = "Ball";

    #region Trigger

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag(checkBallTag))
            {
                CountPoints();
            }
            
        }


    #endregion

    #region Points

        private void CountPoints()
        {
            StateMachine.Instance.ResetPosition();
            player.AddPoints();
        }

    #endregion
}
