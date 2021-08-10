using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static StateMachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public BallBase ballBase;
    public StateMachine stateMachine;
    public Player playerOne;
    public Player playerTwo;

    [Header("Menus")]
    public GameObject uiMainMenu;
    public WinnerScreen uiWinnerScreen;

    private void Awake()
    {
        Instance = this;
    }

    public void RestartBall()
    {
        ResetBall();

        Invoke(nameof(ReleaseBall), 3);
    }

    public void RestartGame()
    {
        ResetBall();

        playerOne.ResetPlayer();
        playerTwo.ResetPlayer();
    }

    public void StartGame()
    {
        ballBase.StartBall();
    }

    public void EndGame(string playerName)
    {
        stateMachine.SetState(State.END_GAME, playerName);
    }

    public void ShowMainMenu()
    {
        ballBase.CanMove(false);
        uiMainMenu.SetActive(true);
    }

    public void ShowWinnerScreen(string playerName)
    {
        RestartGame();
        uiWinnerScreen.SetWinnerMessage(playerName);
        uiWinnerScreen.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    private void ReleaseBall()
    {
        ballBase.CanMove(true);
        ballBase.ReleaseBall();
    }

    //Reset ball position
    private void ResetBall()
    {
        ballBase.ResetBall();
    }

}
