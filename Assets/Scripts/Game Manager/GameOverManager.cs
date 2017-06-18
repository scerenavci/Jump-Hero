using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{

    public static GameOverManager instance;

    private GameObject gameOverPanel;
    private Animator gameOverAnim;

    private GameObject scoreText;
    private Button playAgainBtn, backBtn;
    private Text finalScore;

    void Awake()
    {
        MakeInstance();
        InitializeVariables();
    }

    void MakeInstance()
    {
        if (instance ==null)
            instance = this;
    }

    public void GameOverShowPanel()
    {
        scoreText.SetActive(false);
        gameOverPanel.SetActive(true);

        finalScore.text = "Score\n" + "" + ScoreManager.instance.GetScore();
        gameOverAnim.Play("FadeIn");
    }
    void InitializeVariables()
    {
        gameOverPanel = GameObject.Find("Game Over Panel Holder");
        gameOverAnim = gameOverPanel.GetComponent<Animator>();

        playAgainBtn = GameObject.Find("Play Again Button").GetComponent<Button>();
        backBtn = GameObject.Find("Back Button").GetComponent<Button>();

        scoreText =GameObject.Find("Score Text");
        finalScore = GameObject.Find("Game Over Score").GetComponent<Text>();

        playAgainBtn.onClick.AddListener(() => PlayAgain());
        backBtn.onClick.AddListener(() => BackToMenu());

        gameOverPanel.SetActive(false);
    } //InitializeVariables


    public void PlayAgain()
    {
        Application.LoadLevel(Application.loadedLevelName);
    } //PlayAgain

    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
    } //BackToMenu
}






















