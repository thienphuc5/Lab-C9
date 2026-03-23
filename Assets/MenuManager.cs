using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void StartGame()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            Debug.Log("Chưa nhập tên!");
            return;
        }

        // 🔥 Lưu vào GameManager (KHÔNG dùng static nữa)
        GameManager.Instance.playerName = nameInput.text;
        GameManager.Instance.level = 1;

        SceneManager.LoadScene("Battle");
    }
}