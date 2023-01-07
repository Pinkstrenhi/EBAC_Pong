using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallBase : MonoBehaviour
{
    public Vector3 speed = new Vector3(1,1,0);
    private Vector3 _startSpeed;
    public string checkTag = "Player";
    private Image _uiBall;
    private bool _movementDisabled = false;
    [Header("Randomization")] 
    public Vector2 randomSpeedY = new Vector2(5,10);
    public Vector2 randomSpeedX = new Vector2(5,10);

    private Vector3 _starPosition;
    private bool _canMove = false;

    #region UnityMethods
        private void Awake()
        {
            _uiBall = GetComponent<Image>();
            _starPosition = transform.position;
            _startSpeed = speed;
        }

        private void Update()
        {
            if (!_canMove || _movementDisabled)
            {
                return;
            }
            transform.Translate(speed);
        }

    #endregion

    #region Colissions

        private void OnCollisionEnter2D(Collision2D other)
        {
            _uiBall.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            if (other.gameObject.CompareTag(checkTag))
            {
                OnPlayerCollision();
            }
            else
            {
                speed.y *= -1;
            }
        }

        private void OnPlayerCollision()
        {
            speed.x *= -1;
            float randomX = Random.Range(randomSpeedX.x, randomSpeedX.y);
            if (speed.x < 0)
            {
                randomX = -randomX;
            }

            speed.x = randomX;
            
            float randomY = Random.Range(randomSpeedY.x, randomSpeedY.y);
            speed.y = randomY;
        }

    #endregion

    #region Reset

        public void ResetPosition()
        {
            transform.position = _starPosition;
            speed = _startSpeed;
        }

        public void DisableMovement()
        {
            _movementDisabled = true;
        }

    #endregion

    #region CanMove

        public void CanMove(bool state)
        {
            _canMove = state;
        }

    #endregion

   
}
