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

    PlayerStats player;

    private void Start()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerStats>();

        playing.SetActive(true);
        defeated.SetActive(false);

        ChangeLife();
        ChangePoints();

        Cursor.visible = false;
    }

    void OnEnable()
    {
        PlayerStats.RefreshLife += ChangeLife;
        PlayerStats.RefreshPoints += ChangePoints;
        PlayerStats.RefreshFinalPoints += ChangeFinalPoints;
    }

    void OnDisable()
    {
        PlayerStats.RefreshLife -= ChangeLife;
        PlayerStats.RefreshPoints -= ChangePoints;
        PlayerStats.RefreshFinalPoints -= ChangeFinalPoints;
    }

    void Update()
    {
        Playing();
    }

    void Playing()
    {
        if (player.GetIsDead())
        {
            playing.SetActive(false);
            defeated.SetActive(true);
            Cursor.visible = true;
        }
    }

    void ChangeLife()
    {
        textHealth.text = player.health.ToString();
        textArmor.text = player.armor.ToString();
    }

    void ChangePoints()
    {
        textPoints.text = player.totalPoints.ToString();
        textKills.text = player.totalKills.ToString();
    }

    void ChangeFinalPoints()
    {
        textFinalPoints.text = player.totalPoints.ToString();
        textFinalKills.text = player.totalKills.ToString();
    }
}
