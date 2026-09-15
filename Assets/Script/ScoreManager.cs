using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fallSpeedText;

    public Rigidbody playerRb;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScore();
    }

    void Update()
    {
        float fallSpeed = -playerRb.linearVelocity.y;

        fallSpeedText.text = "Fall Speed: " + fallSpeed.ToString("F2");
    }

    public void AddScore(int amount)
    {
        score += amount;

        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score + "/5";
    }
}