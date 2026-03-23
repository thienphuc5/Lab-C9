using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [Header("Player Settings")]
    public float playerSpeed = 5f;
    public int maxHealth = 100;

    [Header("Enemy Settings")]
    public int enemyCount = 10;
    public float enemySpeed = 3f;

    [Header("Game Settings")]
    public int maxLevel = 5;
    public float spawnRate = 2f;
}