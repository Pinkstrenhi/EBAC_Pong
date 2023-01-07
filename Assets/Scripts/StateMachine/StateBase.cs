using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

    #region StatesBase

    public class StateBase
    {
        
        public virtual void OnStateEnter(object o = null)
        {
            //Debug.Log("OnStateEnter");
        }

        public virtual void OnStateStay()
        {
            //Debug.Log("OnStateStay");
        }

        public virtual void OnStateExit()
        {
            //Debug.Log("OnStateExit");
        }
    }

#endregion

    #region PlayState

    public class StatePlaying : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
            BallBase ballObject = (BallBase) o;
            GameManager.Instance.StartGame();
            base.OnStateEnter(o);
        }
    }

#endregion

    #region ResetState

        public class StateResetPosition : StateBase
        {
            public override void OnStateEnter(object o = null)
            {
                GameManager.Instance.ResetBall();
                base.OnStateEnter(o);
            }
        }

#endregion
    #region EndGameState
    public class StateEndGame : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
            GameManager.Instance.ResetPlayers();
            GameManager.Instance.ShowMainMenu();
            GameManager.Instance.ResetBall(false);
            base.OnStateEnter(o);
        }
    }
#endregion
