using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public float highScore = 0f;

    private static SingletonManager instance;

    public static SingletonManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SingletonManager>();
                if(instance == null)
                {
                    instance = new GameObject().AddComponent<SingletonManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null) Destroy(this);
        DontDestroyOnLoad(this);
    }
}
