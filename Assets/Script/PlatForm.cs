using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlatForm : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI resultText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            // ความเร็วตอนลงจอด
            float fallspeed = Mathf.Abs(collision.relativeVelocity.y);

            Debug.Log("Fall Speed: " + fallspeed);
            Debug.Log("Fuel: " + player.currentFuel);
            Debug.Log("Score: " + ScoreManager.instance.score);

            // =================================
            // กรณีเก็บเหรียญครบ 5 เหรียญแล้ว
            // =================================
            if (ScoreManager.instance.score >= 5)
            {
                // ลงจอดไม่แรงเกินไป = ชนะ
                if (fallspeed <= 10)
                {
                    Debug.Log("YOU WIN!");

                    collision.gameObject.SetActive(false);
                    endPanel.SetActive(true);
                    resultText.text = "YOU WIN!";
                }
                // ลงจอดแรงเกินไป = แพ้
                else
                {
                    Debug.Log("BOOM - YOU LOSE");

                    collision.gameObject.SetActive(false);
                    endPanel.SetActive(true);
                    resultText.text = "BOOM!\nYOU LOSE";
                }

                return;
            }

            // =================================
            // กรณีเก็บเหรียญยังไม่ครบ
            // =================================

            // ถ้าน้ำมันยังเหลือ → ยังไม่จบ
            if (player.currentFuel > 0)
            {
                Debug.Log("เหรียญยังไม่ครบ และน้ำมันยังเหลือ → เล่นต่อ");
                return;
            }

            // เหรียญไม่ครบ + น้ำมันหมด = แพ้
            Debug.Log("เหรียญไม่ครบ + น้ำมันหมด = YOU LOSE");

            collision.gameObject.SetActive(false);
            endPanel.SetActive(true);
            resultText.text = "YOU LOSE";
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}