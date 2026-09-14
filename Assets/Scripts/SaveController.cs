using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    private static SaveController _instance;


    public string namePlayer;
    public string nameEnemy;

    public string savedWinner = "SavedWinner";

    public static SaveController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<SaveController>();

                if (_instance == null)
                {
                    GameObject singleObject = new GameObject(typeof(SaveController).Name);
                    _instance = singleObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this; 
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(savedWinner, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(savedWinner);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}