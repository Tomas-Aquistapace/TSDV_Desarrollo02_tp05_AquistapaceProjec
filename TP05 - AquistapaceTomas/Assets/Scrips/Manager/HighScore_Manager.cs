using UnityEngine;
using TMPro;

public class HighScore_Manager : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    void OnEnable()
    {
        highScore.text = SingletonManager.Instance.highScore.ToString();
    }
}
