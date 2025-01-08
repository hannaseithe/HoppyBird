using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text highScoreText;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool birdDead = false;
    public AudioSource audio1;
    public AudioSource audio2;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore",0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        audio1.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        audio2.Play();
        gameOverScreen.SetActive(true);
        birdDead = true;
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", playerScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        
        
    }
}
