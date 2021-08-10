using UnityEngine;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public Player player;

    private void Start()
    {
        
    }

    public void ChangeName()
    {
        uiTextName.text = uiInputField.text;
        player.SetName(uiTextName.text);
        changeNameInput.SetActive(false);
    }
}
