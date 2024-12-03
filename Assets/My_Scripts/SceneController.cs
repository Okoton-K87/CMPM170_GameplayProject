using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
