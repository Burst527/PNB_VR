using UnityEngine;
using System.Collections;

public class AmbienceManager : MonoBehaviour
{
    public static AmbienceManager instance;

    public float fadeDuration = 1.5f;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
        audioSource.loop = true;
        audioSource.Play();

        StartCoroutine(FadeIn());
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 1f;
    }

    IEnumerator FadeOutRoutine()
    {
        float start = audioSource.volume;
        float t = 0f;

        while (t < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(start, 0f, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = 0f;
    }
}
