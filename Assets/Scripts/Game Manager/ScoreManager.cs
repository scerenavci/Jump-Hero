using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager: MonoBehaviour
{

    public static ScoreManager instance;
    private Text scoreText;
    private int score;

    void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "" + score;
    }

    public int GetScore()
    {
        return this.score;
    }
}
