using UnityEngine;
using System.Collections;

public class GameMusicManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource gameMusic;

    [Header("Settings")]
    [SerializeField] private float fadeDuration = 3f;
    [SerializeField] private float targetVolume = 1f;

    private void Start()
    {
        gameMusic.volume = 0f;
        gameMusic.Play();
        StartCoroutine(FadeIn(gameMusic, fadeDuration, targetVolume));
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.volume = targetVolume;
    }
}
