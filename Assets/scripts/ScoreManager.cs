using UnityEngine;
using TMPro;

// ═══════════════════════════════════════════════════════
// 📝 แบบฝึกหัด: ScoreManager.cs
// หน้าที่: นับคะแนน + Singleton (เรียกใช้จาก Script อื่นได้ทันที)
// เรียกใช้จาก BulletController: ScoreManager.Instance.AddScore(10);
// ═══════════════════════════════════════════════════════

public class ScoreManager : MonoBehaviour
{
    // Singleton — เรียกใช้จาก Script อื่นได้ทันที
    public static ScoreManager Instance;

    [SerializeField] TMP_Text scoreText;
    int score = 0;

    private void Start()
    {
        scoreText.text = "Score : " + score;
    }

    void Awake()
    {
        Instance = GetComponent<ScoreManager>();
    }

    public void AddScore(int pts)
    {
        // 📝 โจทย์: ต้องการเพิ่มคะแนนสะสม (score) ทีละ pts แล้วอัปเดตข้อความ
        // บนจอให้แสดงผลใหม่ทันที ต้องใช้คำสั่งไหน?
        //   A) score += pts; scoreText.text = "Score : " + score;
        //   B) score = pts; scoreText.text = "Score : " + score;
        //   C) score += pts;
        //   D) scoreText.text = "Score : " + pts;
        // ✍️ เขียนคำตอบแทนบรรทัดด้านล่าง:
        /* TODO */
        score += pts; scoreText.text = "Score : " + score;
    }
}
