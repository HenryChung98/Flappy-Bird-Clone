using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // player
    public GameObject player;
    // score
    public int score;
    public static int bestScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    // UI
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }
    void Start()
    {
        // reset
        score = 0;
        if (scoreText != null){
            scoreText.gameObject.SetActive(true);
        }

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Update()
    {
        scoreText.text = score.ToString();

        if (!player){
            GameOver();
        }
    }
    public void AddScore()
    {
        score++;
    }

    private void GameOver(){
        scoreText.gameObject.SetActive(false);
        endScoreText.text = "Score: " + score.ToString();
        if (score > bestScore){
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        
        panel.SetActive(true);
    }
    
    public void Restart(){
        SceneManager.LoadScene("GameScene");
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
    }
}
