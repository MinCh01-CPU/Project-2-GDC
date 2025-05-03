using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject menuBoard;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        menuBoard.SetActive(true);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        menuBoard.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPaused = false;
        Time.timeScale = 1;
        menuBoard.SetActive(false);
    }
}
