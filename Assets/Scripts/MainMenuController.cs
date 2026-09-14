using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    private void Start()
    {
        SaveController.instance.Reset();
        string lastWinner = SaveController.instance.GetLastWinner();

        if (lastWinner != "")
            uiWinner.text = "Ultimo Vencedor " + lastWinner;
        else
            uiWinner.text = "";
    }
}
