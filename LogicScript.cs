using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text highscoreText;
    public Text scoreText;
    public GameObject gameOverScreen;
    // use Unity's PlayerPrefs to save and retrieve the high score. PlayerPrefs stores data between game sessions, so your high score will remain saved even if the game restarts or the application is closed.
    private int highscore;
    private bool isGameOver = true; //flag to check if game is over

    private void Start()
    {

        // Load the high score from PlayerPrefs
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = highscore.ToString();
    }
    
    [ContextMenu("Increase Score")]
   public void addScore(int scoreToAdd)
   {
        if (isGameOver)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
            // Check if the new score is a high score
            if (playerScore > highscore)
            {
                highscore = playerScore;
                highscoreText.text = highscore.ToString();
                // Save the new high score to PlayerPrefs
                PlayerPrefs.SetInt("HighScore", highscore);
            }
        }
        

    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = false;
        gameOverScreen.SetActive(true);

    }
}
