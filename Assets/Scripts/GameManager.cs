using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;

    private int score;
    private int coinScore;

    public bool gameOver = false;
    public AudioSource gameOverAudio;
    public TextMeshProUGUI highScoreText;
    
void Start()
{
   
}

    void Update()
    {
        if (gameOver)
            return;

        score = Mathf.FloorToInt(player.position.z) + coinScore;

        scoreText.text = "Score: " + score;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        highScoreText.text = "Best: " + bestScore;
    }

    public void AddCoin()
    {
        coinScore += 10;
    }

    public void EndGame()
{
    gameOver = true;
    if(score > PlayerPrefs.GetInt("BestScore", 0))
    {
        PlayerPrefs.SetInt("BestScore", score);
    }

    gameOverPanel.SetActive(true);

    gameOverAudio.PlayOneShot(gameOverAudio.clip);}

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}