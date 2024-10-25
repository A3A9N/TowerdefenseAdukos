using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource menuMusic;

    [Header("Settings")]
    [SerializeField] private float fadeDuration = 3f;
    [SerializeField] private float targetVolume = 1f;

    private void Start()
    {

        menuMusic.volume = 0f;
        menuMusic.Play();
        StartCoroutine(FadeIn(menuMusic, fadeDuration, targetVolume));
    }

    public void PlayGameMusic()
    {
        StartCoroutine(FadeOut(menuMusic, fadeDuration));
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

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
    }
}
