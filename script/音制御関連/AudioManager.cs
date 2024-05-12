using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject Player;
    public float fadeDuration = 2f; // フェードの期間（秒）
    private float targetVolume_fadeout = 0f; // 目標の音量

    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = Player.transform.position;

        if (tmp.x >= 2) SomeConditionMet();
        else SomeConditionMet_in(); audioSource.volume = 0.1f;
    }
    void SomeConditionMet()
    {
        StartCoroutine(FadeOut(audioSource, fadeDuration));
    }
    void SomeConditionMet_in()
    {
        if (!audioSource.isPlaying) audioSource.Play();
    }
    IEnumerator FadeOut(AudioSource audioSource, float duration)
    {

        float startVolume = audioSource.volume;
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume_fadeout, (Time.time - startTime) / duration);
            yield return null;
        }

        audioSource.volume = targetVolume_fadeout;
        if (audioSource.isPlaying) audioSource.Stop();
    }
    
}
