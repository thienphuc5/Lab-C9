using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TMP_Text playerText;

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("Không có GameManager!");
            return;
        }

        playerText.text = "Hello " 
                        + GameManager.Instance.playerName
                        + " | Level: "
                        + GameManager.Instance.level;
    }
}