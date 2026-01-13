using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Scene Target")]
    public string targetScene;


    public void SwitchScene()
    {
         SceneManager.LoadScene(targetScene);
        
    }
}
