using UnityEngine.SceneManagement;
using UnityEngine;

public class UISceneManager : MonoBehaviour
{
    [Header("Scenes Names")]
    public string scene;

    public void RunScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
