using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    int score = 0;
    int highScore = 0;

    void Start()
    {
        // 🔥 Lấy HighScore từ PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        highScoreText.text = "High Score: " + highScore;
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        // Test: nhấn Space để tăng điểm
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            scoreText.text = "Score: " + score;

            CheckHighScore();
        }
    }

    void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;

            // 🔥 LƯU
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            highScoreText.text = "High Score: " + highScore;

            Debug.Log("Đã lưu HighScore: " + highScore);
        }
    }
}