using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetScene;   // nama scene tujuan

     public void SwitchScene()
    {
        string current = SceneManager.GetActiveScene().name;
    
        if (current == targetScene)
            SceneManager.LoadScene(current);
        else
            SceneManager.LoadScene(targetScene);
    }
    
   
    
}
