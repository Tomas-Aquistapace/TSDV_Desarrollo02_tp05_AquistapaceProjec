using UnityEngine.SceneManagement;
using UnityEngine;

public class UImanager_menu : MonoBehaviour
{
    [Header("Scenes Names")]
    public string mainGame;

    public void PlayMainGame()
    {
        SceneManager.LoadScene(mainGame);
    }
}
