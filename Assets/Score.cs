using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int currentScore;

    private Text text;

    private SpawnEnemies enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        text = gameObject.GetComponent<Text>();
        enemySpawner = GameObject.Find("Main Camera").GetComponent<SpawnEnemies>();

    }

    public void IncrementScore()
    {
        currentScore++;
        text.text = $"Score: {currentScore}";
        if (currentScore % 10 == 0)
        {
            enemySpawner.IncreaseSpawnRate();
        }

    }
}
