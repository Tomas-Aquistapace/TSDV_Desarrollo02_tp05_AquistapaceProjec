using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    [Header("Player Resourses")]
    public GameObject playing;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textArmor;
    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI textKills;


    [Header("Final Score")]
    public GameObject defeated;
    public TextMeshProUGUI textFinalPoints;
    public TextMeshProUGUI textFinalKills;

    [Header("Player Stats")]
    public PlayerStats player;

    private void Start()
    {
        playing.SetActive(true);
        defeated.SetActive(false);
    }

    void Update()
    {
        Playing();
    }

    void Playing()
    {
        if (!player.GetIsDead())
        {
            textHealth.text = player.health.ToString();
            textArmor.text = player.armor.ToString();
            textPoints.text = player.totalPoints.ToString();
            textKills.text = player.totalKills.ToString();
        }
        else
        {
            playing.SetActive(false);
            defeated.SetActive(true);

            textFinalPoints.text = player.totalPoints.ToString();
            textFinalKills.text = player.totalKills.ToString();
        }
    }
}
