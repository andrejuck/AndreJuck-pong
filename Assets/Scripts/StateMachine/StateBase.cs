using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
    public virtual void OnStateExit()
    {
        //Debug.Log("OnStateExit");
    }

    public virtual void OnStateEnter(object o = null)
    {
        //Debug.Log("OnStateEnter");
    }

    public virtual void OnStateStay()
    {
        //Debug.Log("OnStateStay");
    }
}

public class StateRunning : StateBase
{
    public Player player;
    public override void OnStateEnter(object o = null)
    {

        base.OnStateEnter(o);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}

public class StatePlaying : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        //BallBase ball = (BallBase)o;
        GameManager.Instance.StartGame();
    }
}

public class StateResetPosition : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);

        GameManager.Instance.RestartBall();
    }
}

public class StateResetGame : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);

        GameManager.Instance.RestartGame();
    }
}

public class StateEndGame : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);

        var message = (string)o;
        GameManager.Instance.ShowWinnerScreen(message);
    }
}