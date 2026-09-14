using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImputFild : MonoBehaviour
{
    public bool isPlayer;
    public TMP_InputField inputField;

    private void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
    }

    public void UpdateName(string name)
    {
        if (isPlayer)
            SaveController.instance.namePlayer = name;
        else
            SaveController.instance.nameEnemy = name;
          

    }
}
