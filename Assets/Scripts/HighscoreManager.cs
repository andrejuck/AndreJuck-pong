using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    private string keyToSave = "HighscoreKey";

    public static HighscoreManager Instance;

    [Header("References")]
    public TextMeshProUGUI uiTextHighscore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(keyToSave, "Empty highscore");
    }

    public void SavePlayerWin(Player player)
    {
        if (string.IsNullOrEmpty(player.playerName)) return;
        PlayerPrefs.SetString(keyToSave, player.playerName);
        UpdateText();
    }
}
