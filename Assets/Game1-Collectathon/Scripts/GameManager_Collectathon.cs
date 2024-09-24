using UnityEngine;
using TMPro;
public class GameManager_Collectathon : MonoBehaviour
{
    
    public static GameManager_Collectathon instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject winText;
    public GameObject gameOverText;
    private int score = 0;
    private int totalCollectibles;
    private float timer = 120f; // 2 minutes
    void Awake()
    {
        instance = this;
    }
    void Start()
    {

        
        UpdateScoreText();
        winText.SetActive(false);
        gameOverText.SetActive(false);
        totalCollectibles = FindObjectsOfType<Collectible>().Length;
        
        
    }
    void Update()
    {
        if (totalCollectibles <= 0)
        {
            totalCollectibles = FindObjectsOfType<Collectible>().Length;
            Debug.Log(totalCollectibles);
        }
        timer -= Time.deltaTime;
        UpdateTimerText();
        if (timer <= 0)
        {
            GameOver();
        }
        if (score >= totalCollectibles)
        {
            Win();
        }
    }
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        
        
    }
    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();

    }
    void Win()
    {
        winText.SetActive(true);
        Time.timeScale = 0f;
    }
    void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }
}

