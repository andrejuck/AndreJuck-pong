using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 5;
    public string playerName;
    public Image uiPlayer;

    [Header("Key Setup")]
    public KeyCode keyMoveUp = KeyCode.UpArrow;
    public KeyCode keyMoveDown = KeyCode.DownArrow;

    

    Rigidbody2D rgb2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI currentPointTextUI;

    [Header("Position")]
    public Vector3 startPosition;

    private void Awake()
    {
        rgb2D = transform.GetComponent<Rigidbody2D>();
        startPosition = rgb2D.position;
        ResetPlayer();
    }

    private void Update()
    {
        if (Input.GetKey(keyMoveUp))
            rgb2D.MovePosition(transform.position + transform.up * speed);

        if (Input.GetKey(keyMoveDown))
            rgb2D.MovePosition(transform.position + transform.up * -speed);
    }

    private void UpdateUI()
    {
        currentPointTextUI.text = currentPoints.ToString();
    }

    private bool GameHasEnded()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame(playerName);
            HighscoreManager.Instance.SavePlayerWin(this);

            return true;
        }

        return false;
    }

    public void SetName(string text)
    {
        playerName = text;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        rgb2D.position = startPosition;

        UpdateUI();
    }

    public void ChangeColor(Color color)
    {
        uiPlayer.color = color;
    }

    public void AddPoint()
    {
        currentPoints++;
        if (!GameHasEnded()) 
        {
            StateMachine.Instance.ResetPosition();            
        }

        UpdateUI();
    }
}
