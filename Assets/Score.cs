using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int currentScore;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        text = gameObject.GetComponent<Text>();
    }

    public void IncrementScore()
    {
        currentScore++;
        text.text = $"Score: {currentScore}";

    }
}
