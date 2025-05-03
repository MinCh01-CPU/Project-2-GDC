using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
