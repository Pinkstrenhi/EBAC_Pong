using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StateMachine : MonoBehaviour
{
   public static StateMachine Instance;
   #region Enum
      public enum States
      {
         menu,
         playing, 
         resetPosition,
         endGame
      }
      
   #endregion
   public Dictionary<States, StateBase> DictionaryState;
   private StateBase _currentState;
   public Player player;

   #region UnityMethods
      private void Awake()
      {
         Instance = this;
         DictionaryState = new Dictionary<States, StateBase>();
         DictionaryState.Add(States.menu, new StateBase());
         DictionaryState.Add(States.playing, new StatePlaying());
         DictionaryState.Add(States.resetPosition, new StateResetPosition());
         DictionaryState.Add(States.endGame, new StateEndGame());
         SwitchStates(States.menu);
      }
      private void Update()
      {
         if (_currentState != null)
         {
            _currentState.OnStateStay();
         }
      }

   #endregion

   #region Switch

      public void SwitchStates(States state)
      {
         if (_currentState != null)
         {
            _currentState.OnStateExit();
         }

         _currentState = DictionaryState[state];
         _currentState.OnStateEnter(player);
         
         if (_currentState != null)
         {
            _currentState.OnStateEnter();
         }

      }

   #endregion

   #region Reset

      public void ResetPosition()
      {
         SwitchStates(States.resetPosition);
      }

   #endregion
   
}
