using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public Text timerText; // Reference to UI Text component
    public bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime;
            timeRemaining = Mathf.Max(timeRemaining, 0); // Prevent negative time
            UpdateTimerDisplay();

            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    public void AddTime(float timeToAdd)
    {
        timeRemaining += timeToAdd;
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        isGameOver = true;
        SceneManager.LoadScene("ScoreScreen");
        Debug.Log("Time's up!");
        // Trigger end game logic here
    }
}

