using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// ═══════════════════════════════════════════════════════
// 📝 แบบฝึกหัด: PlayerHealth.cs
// หน้าที่: HP + Game Over
// ═══════════════════════════════════════════════════════

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 3;
    [SerializeField] TMP_Text hpText;
    int hp;

    void Start()
    {
        hp = maxHp;
        Refresh();
    }

    public void TakeDamage(int dmg)
    {
        // 📝 โจทย์: ต้องการลด HP ปัจจุบันลงตามค่า dmg ที่ได้รับ แล้วอัปเดต
        // ข้อความบนจอให้ตรงกับ HP ใหม่ ต้องใช้คำสั่งไหน?
        //   A) hp -= dmg; Refresh();
        //   B) hp = dmg; Refresh();
        //   C) hp -= dmg;
        //   D) maxHp -= dmg; Refresh();
        // ✍️ เขียนคำตอบแทนบรรทัดด้านล่าง:
        /* TODO */
        hp -= dmg; Refresh();
        if (hp <= 0)
            SceneManager.LoadScene("GameOver");
    }

    void Refresh()
    {
        hpText.text = "HP : " + hp;
    }
}

