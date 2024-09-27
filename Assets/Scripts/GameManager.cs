using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // player
    public GameObject player;
    // score
    public int score;
    public static int bestScore;
    [SerializeField] private Image newRecord;
    [SerializeField] private Image Medal;
    [SerializeField] private Sprite bronze;
    [SerializeField] private Sprite silver;
    [SerializeField] private Sprite gold;
    [SerializeField] private Sprite platinum;
    [SerializeField] private TextMeshProUGUI scoreText;

    // pause 
    private bool isPaused = false;
    [SerializeField] private Button PauseBtn;
    [SerializeField] private GameObject pausePanel;

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
        
        Time.timeScale = isPaused ? 0 : 1;

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
        endScoreText.text = score.ToString();
        if (score > bestScore){
            bestScore = score;
            newRecord.gameObject.SetActive(true);
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        bestScoreText.text = bestScore.ToString();
        
        PauseBtn.gameObject.SetActive(false);
        panel.SetActive(true);

        if (score >= 40){
            Medal.sprite = platinum;
        }
        else if (score >= 30){
            Medal.sprite = gold;
        }
         else if (score >= 20){
            Medal.sprite = silver;
        }
         else if (score >= 10){
            Medal.sprite = bronze;
        }
        else{
            Medal.gameObject.SetActive(false);
            Medal.sprite = null;
        }
    }
    
    public void Restart(){
        SceneManager.LoadScene("GameScene");
    }

    public void BackMainMenu(){
        SceneManager.LoadScene("MainScene");
    }

    public void TogglePause()
    {
        isPaused = !isPaused; 
        pausePanel.gameObject.SetActive(isPaused);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
    }
}
