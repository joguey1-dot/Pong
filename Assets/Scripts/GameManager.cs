using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ballController;

    public int winPoints = 2;

    public int enemyscore = 0;
    public int playerscore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public TextMeshProUGUI textEndGame;

    public GameObject screenEndGame;

    void Start()
    {
        ResetGame();  
    }

    public void ResetGame()
    {
        playerPaddle.position = new Vector3(7, 0f, 0f);
        enemyPaddle.position = new Vector3(-7, 0f, 0f);

        ballController.ResetBall();

        playerscore = 0;
        enemyscore = 0;

        textPointsEnemy.text = enemyscore.ToString();
        textPointsPlayer.text = playerscore.ToString();
        
        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerscore++;
        textPointsPlayer.text = playerscore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyscore++;
        textPointsEnemy.text = enemyscore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyscore >= winPoints || playerscore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    private void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.instance.GetName(playerscore > enemyscore);
        textEndGame.text = "Vitória " + SaveController.instance.GetName(playerscore > enemyscore);
        SaveController.instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);

    }
        
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
