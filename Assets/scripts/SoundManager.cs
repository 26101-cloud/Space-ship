using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ═══════════════════════════════════════════════════════
// 🔊 SoundManager.cs
// หน้าที่: จัดการเสียงเพลง (Music) และเสียงเอฟเฟกต์ (Effect) ของทั้งเกม
//         เป็น Singleton ตัวเดียวในเกม อยู่ข้ามซีนได้ (DontDestroyOnLoad)
// วิธีใช้: วาง Component นี้บน Empty GameObject ในซีนแรก แล้วลาก AudioClip
//         ใส่ musicClips / effectClips ใน Inspector
//         เรียกใช้จากสคริปต์อื่นผ่าน SoundManager.Instance.PlayMusic(...) เป็นต้น
// ═══════════════════════════════════════════════════════

[System.Serializable]
public class AudioResource
{
    public string Name;
    public AudioClip Clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource effectSource;

    [Header("Clip Library")]
    [SerializeField] List<AudioResource> musicClips = new List<AudioResource>();
    [SerializeField] List<AudioResource> effectClips = new List<AudioResource>();

    [Header("Fade Settings")]
    [SerializeField] float defaultFadeDuration = 1f;

    Coroutine fadeRoutine;

    void Awake()
    {
        // Singleton: ถ้ามี SoundManager ตัวอื่นอยู่ก่อนแล้ว ให้ทำลายตัวใหม่ทิ้ง
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (musicSource == null) musicSource = gameObject.AddComponent<AudioSource>();
        if (effectSource == null) effectSource = gameObject.AddComponent<AudioSource>();

        musicSource.playOnAwake = false;
        effectSource.playOnAwake = false;
    }

    // ───────────── Music (เล่นทีละเพลง, Loop ได้, Fade ได้) ─────────────

    public void PlayMusic(string clipName, bool loop = true, bool fade = true)
    {
        AudioResource resource = musicClips.Find(r => r.Name == clipName);
        if (resource == null)
        {
            Debug.LogWarning($"SoundManager: ไม่พบเพลงชื่อ '{clipName}' ใน musicClips");
            return;
        }
        PlayMusic(resource.Clip, loop, fade);
    }

    public void PlayMusic(AudioClip clip, bool loop = true, bool fade = true)
    {
        if (clip == null) return;
        if (musicSource.clip == clip && musicSource.isPlaying) return;

        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);

        musicSource.loop = loop;

        if (fade)
        {
            fadeRoutine = StartCoroutine(FadeToNewMusic(clip, defaultFadeDuration));
        }
        else
        {
            musicSource.clip = clip;
            musicSource.volume = 1f;
            musicSource.Play();
        }
    }

    public void StopMusic(bool fade = true)
    {
        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);

        if (fade)
            fadeRoutine = StartCoroutine(FadeOutAndStop(defaultFadeDuration));
        else
            musicSource.Stop();
    }

    IEnumerator FadeToNewMusic(AudioClip newClip, float duration)
    {
        float startVolume = musicSource.volume;

        // Fade out เพลงเดิม (ถ้ากำลังเล่นอยู่)
        if (musicSource.isPlaying)
        {
            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                musicSource.volume = Mathf.Lerp(startVolume, 0f, t / duration);
                yield return null;
            }
        }

        musicSource.clip = newClip;
        musicSource.volume = 0f;
        musicSource.Play();

        // Fade in เพลงใหม่
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0f, 1f, t / duration);
            yield return null;
        }

        musicSource.volume = 1f;
    }

    IEnumerator FadeOutAndStop(float duration)
    {
        float startVolume = musicSource.volume;

        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, t / duration);
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;
    }

    // ───────────── Sound Effect (เล่นรอบเดียว, ซ้อนกันได้ด้วย PlayOneShot) ─────────────

    public void PlayEffect(string clipName)
    {
        AudioResource resource = effectClips.Find(r => r.Name == clipName);
        if (resource == null)
        {
            Debug.LogWarning($"SoundManager: ไม่พบเสียงชื่อ '{clipName}' ใน effectClips");
            return;
        }
        PlayEffect(resource.Clip);
    }

    public void PlayEffect(AudioClip clip)
    {
        if (clip == null) return;
        effectSource.PlayOneShot(clip);
    }
}
