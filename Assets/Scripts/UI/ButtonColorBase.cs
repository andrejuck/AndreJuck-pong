using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;
    public Player myPlayer;

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        uiImage.color = color;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
}
