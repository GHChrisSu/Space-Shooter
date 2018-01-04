using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public int score;
    private bool gameOver;
    private bool restart;

    IEnumerator SpawnWaves()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver == true)
            {
                restartText.text = "Press 'R' to restart!";
                restart = true;
                break;
            }
        }

    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    // Use this for initialization
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        StartCoroutine(SpawnWaves());
        UpdateScore();
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
