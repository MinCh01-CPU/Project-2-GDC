using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    private bool isPaused;
    public bool victory;
    public bool isdead;
    [SerializeField] private GameObject victoryBoard;
    [SerializeField] private GameObject deadBoard;

    [SerializeField] private GameObject menuBoard;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
        if(victory){
            Victory();
        }
        if(isdead){
            Dead();
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
    public void Victory(){
        Time.timeScale = 0;
        victoryBoard.SetActive(true);
    }
    public void Dead(){
        Time.timeScale = 0;
        deadBoard.SetActive(true);
    }
    
}
