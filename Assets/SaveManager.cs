using UnityEngine;
using System.IO;
using System.Diagnostics; // để mở file sau khi lưu
using Debug = UnityEngine.Debug; // tránh nhầm lẫn với System.Diagnostics.Debug

public class SaveManager : MonoBehaviour
{
    string path;

    // Tham chiếu GameConfig từ Lab 5
    public GameConfig gameConfig;

    void Start()
    {
        // Lưu file JSON vào Downloads
        string downloadsFolder = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile),
            "Downloads"
        );

        path = Path.Combine(downloadsFolder, "gameconfig.json");

        // Tạo folder nếu chưa có
        string folder = Path.GetDirectoryName(path);
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        Debug.Log("Đường dẫn lưu file JSON: " + path);

        // 🔥 Gọi SaveConfig ngay khi Start
        if (gameConfig != null)
            SaveConfig();
        else
            Debug.LogWarning("GameConfig chưa được gán trong Inspector!");
    }

    // 🔥 SAVE CONFIG
    public void SaveConfig()
    {
        // Chuyển GameConfig sang JSON
        string json = JsonUtility.ToJson(gameConfig, true);
        File.WriteAllText(path, json);

        Debug.Log("Đã lưu GameConfig JSON vào Downloads!");
        Debug.Log("Nội dung JSON:\n" + json);

        // Mở file JSON ngay sau khi lưu
        OpenFile();
    }

    // 🔥 LOAD CONFIG
    public GameConfig LoadConfig()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            // Tạo một instance GameConfig tạm để load dữ liệu
            GameConfig tempConfig = ScriptableObject.CreateInstance<GameConfig>();
            JsonUtility.FromJsonOverwrite(json, tempConfig);

            Debug.Log("Đã load GameConfig JSON!");
            Debug.Log("Nội dung JSON:\n" + json);
            return tempConfig;
        }
        else
        {
            Debug.Log("Chưa có file GameConfig trong Downloads!");
            return null;
        }
    }

    // 🔥 Mở file JSON bằng Explorer
    private void OpenFile()
    {
        if (File.Exists(path))
        {
            Process.Start("explorer.exe", path);
        }
    }
}