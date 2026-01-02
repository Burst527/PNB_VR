using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AmbientAudioManager : MonoBehaviour
{
    public static AmbientAudioManager instance;

    public AudioSource source;
    public float fadeDuration = 1.5f;

    void Awake()
    {
        // Singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (source == null)
            source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.loop = true;
        source.playOnAwake = false;
        source.volume = 0;
        source.Play();
        StartCoroutine(FadeIn());
    }

    public void FadeOutAndChangeScene(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            source.volume = t / fadeDuration;
            yield return null;
        }
        source.volume = 1;
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        float startVol = source.volume;
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, 0, t / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);
        StartCoroutine(FadeIn());
    }
}
