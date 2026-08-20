using UnityEngine;
using UnityEngine.SceneManagement;

// ═══════════════════════════════════════════════════════
// 📝 แบบฝึกหัด: MainMenuManager.cs
// หน้าที่: ปุ่ม Start / Quit
// Scene: MainMenu (index 0) → GameScene (index 1) → GameOver (index 2)
// ═══════════════════════════════════════════════════════

public class MainMenuManager : MonoBehaviour
{
    // 📝 โจทย์: ต้องการให้ปุ่ม "Start" ใน UI เรียกฟังก์ชันนี้ผ่าน Button OnClick()
    // ได้ แล้วโหลด Scene ชื่อ "GameScene" ต้องเขียนฟังก์ชันแบบไหน?
    //   A) public void StartGame() { SceneManager.LoadScene("GameScene"); }
    //   B) public void StartGame() { SceneManager.LoadScene(0); }
    //   C) void StartGame() { SceneManager.LoadScene("GameScene"); }
    //   D) public void StartGame() { Destroy(gameObject); }
    // ✍️ เขียนฟังก์ชันแทนบรรทัดด้านล่าง:
    /* TODO */
    public void StartGame() { SceneManager.LoadScene("GameScene"); }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
