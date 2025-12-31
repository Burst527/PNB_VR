using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetScene;   // nama scene tujuan

     public void SwitchScene()
    {
        if (AmbienceManager.instance != null)
            AmbienceManager.instance.FadeOut();
    
        Invoke(nameof(LoadScene), 1.5f);
    }
    
    void LoadScene()
    {
        string current = SceneManager.GetActiveScene().name;
    
        if (current == targetScene)
            SceneManager.LoadScene(current);
        else
            SceneManager.LoadScene(targetScene);
    }
   
    
}
