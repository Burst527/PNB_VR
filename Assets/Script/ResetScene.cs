using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetScene;

    public void SwitchScene()
    {
        string current = SceneManager.GetActiveScene().name;

        // ✅ reload scene SELALU BOLEH
        if (current == targetScene)
        {
            SceneManager.LoadScene(current);
            return;
        }

        // ❌ pindah scene lain → cek quest
        if (!QuestManager.Instance.IsQuestCompleted())
            return;

        SceneManager.LoadScene(targetScene);
    }
}
