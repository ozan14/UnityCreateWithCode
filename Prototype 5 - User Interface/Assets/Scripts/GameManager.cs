using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI livesText;
    public GameObject pauseScreen;

    private bool pauseScreenActive;
    public int lives;
    public bool gameOverStatus;
    private int score;
    private float spawnRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !gameOverStatus)
        {
            PauseGame();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (!gameOverStatus)
        {
            yield return new WaitForSeconds(spawnRate);
            int maxIndex = gameObjects.Count;
            Instantiate(gameObjects[Random.Range(0,maxIndex)]);
        }
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    public void updateLives(int livesChange)
    {
        lives += livesChange;
        livesText.text = "Lives : " + lives;
        if (lives < 1)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverStatus = true;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        pauseScreenActive = false;
        updateLives(0);
        gameOverStatus = false;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        updateScore(0);
        titleScreen.SetActive(false);
    }
    private void PauseGame()
    {
        pauseScreenActive = !pauseScreenActive;
        pauseScreen.SetActive(pauseScreenActive);
        Time.timeScale = pauseScreenActive ? 0 : 1;
    }
}
