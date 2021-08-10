using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerScreen : MonoBehaviour
{
    public string message = "{0} WINS";
    public TextMeshProUGUI txtWinnerScreen;

    public void SetWinnerMessage(string playerName)
    {
        message = string.Format(message, playerName);
        txtWinnerScreen.text = message;
    }
}
