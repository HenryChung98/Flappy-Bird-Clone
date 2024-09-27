[View the project log](https://henrychung98.github.io/project/flappyBirdClone/)

### Tech
- Unity
- C#

### Sources
- [Sprites](https://www.spriters-resource.com/fullview/59894/)
- [Sounds](https://pixabay.com/sound-effects/)
  
### Features
- Obstacle Generation
- Scoring System
- Game Over
- Reset Functionality
- Sound Effects

### SomeImgs



### Background

Render two background prefabs and they move to left. When background.position.x reach to out of the frame, reset position.x

```csharp
public class Background : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < -2.3f){
            transform.position = new Vector3(20.5f, 1.9f, 0);
            }
    }
}
```

### Pipe

Created a spawner and it spawns a pipe at random(-2,6, 2.8) position.y

```csharp
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    private float maxY = 2.8f;
    private float minY = -2.6f;

    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe(){
        while (true){
            float spawnY = Random.Range(minY, maxY);

            Instantiate(pipes, new Vector3(transform.position.x, spawnY, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
```

Pipe itself destroys when it's position.x reach to -4.5

```csharp
public class Pipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < -4.5f){
            Destroy(gameObject);
        }
    }
}
```

### Player

```csharp

```

### Game Manager

Scene Load functions

```csharp
    public void Restart(){
        SceneManager.LoadScene("GameScene");
    }

    public void BackMainMenu(){
        SceneManager.LoadScene("MainScene");
    }
```

Get best score from unity database when start.

```csharp
void Start()
    {
        // reset
        score = 0;
        if (scoreText != null){
            scoreText.gameObject.SetActive(true);
        }

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }
```

check isPaused. when isPaused true, pause

```csharp
    void Update()
    {
        scoreText.text = score.ToString();

        Time.timeScale = isPaused ? 0 : 1;

        if (!player){
            GameOver();
        }
    }
```
```csharp
    public void TogglePause()
    {
        isPaused = !isPaused; 
        pausePanel.gameObject.SetActive(isPaused);
    }
```

When gameover, check current score is greater than best score. if true, update best score and display 'new'

Medal displayed depending on the score

```csharp
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
```
