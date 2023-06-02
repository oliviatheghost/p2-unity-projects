using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // Text prefabs to be spawned
    public TextMeshProUGUI scoreText, gameOverText; // Score UI element
    
    public float spawnRate = 1f; //Wait time between spawning target prefabs
    private int score = 0; // Actual score for the game 
    public bool isGameActive;
    public Button restartButton; // will make button restart in game 
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate); // items respawn after a while
            int index = Random.Range(0, targets.Count); // resets count after each use
            Instantiate(targets[index]);
        }
    }

    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; // increment score
        scoreText.text = "Score: " + score; // render new update score
    }


    public void GameOver()
    {
        restartButton.gameObject.SetActive(true); // restart button appars when the game is over 
        gameOverText.gameObject.SetActive(true); // game over writing pops up when game is over
        isGameActive = false;
    }
    

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restarts the game
    }

    public void StartGame(int difficulty)
    {
         isGameActive = true;  // game to start
       score = 0; // set game score to 0 every time
       spawnRate /= difficulty; // set the game difficulty to easy, middle, and hard

       StartCoroutine(SpawnTarget()); // targets with spawn after button is clicked
       UpdateScore(0); // update the score each time you get a point

       titleScreen.gameObject.SetActive(false); // title screen will dissapear after game start
    }
}
