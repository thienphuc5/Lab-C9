using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int level;

    void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // reset luôn
        playerName = "";
        level = 0;
    }
    else
    {
        Destroy(gameObject);
    }
}
}