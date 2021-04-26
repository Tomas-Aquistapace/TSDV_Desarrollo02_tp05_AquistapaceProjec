using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [Header("Canvas Resourses")]
    public Text textHealth;
    public Text textArmor;

    [Header("Player Stats")]
    public PlayerStats player;

    void Update()
    {
        textHealth.text = player.health.ToString();

        textArmor.text = player.armor.ToString();
    }
}
