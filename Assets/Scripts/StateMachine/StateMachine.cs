using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        RESET_GAME,
        END_GAME
    }

    public Dictionary<State, StateBase> dictionaryState;
    public Player player;
    public static StateMachine Instance;

    private StateBase _currentState;

    public void ResetPosition()
    {
        SwitchState(State.RESET_POSITION);
    }

    public void SetState(State state, string message = "")
    {
        SwitchState(state, message);
    }

    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<State, StateBase>();
        dictionaryState.Add(State.MENU, new StateBase());
        dictionaryState.Add(State.PLAYING, new StatePlaying());
        dictionaryState.Add(State.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(State.RESET_GAME, new StateResetGame());
        dictionaryState.Add(State.END_GAME, new StateEndGame());

        SwitchState(State.MENU);
    }

    private void SwitchState(State state, string message = "")
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];
        if(_currentState != null) _currentState.OnStateEnter(message);
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchState(State.PLAYING);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchState(State.RESET_GAME);
        }
    }
}
