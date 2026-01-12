using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("Quest Progress")]
    public int currentObjective = 0;

    [Header("Scene Instructions")]
    public SceneInstructionData[] sceneInstructions;

    SceneInstructionData currentSceneData;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (GameManager.Instance.currentMode == GameMode.FreeRoam)
        {
            gameObject.SetActive(false);
            return;
        }

        LoadSceneInstructionData();
        ShowCurrentInstruction();
    }

    void LoadSceneInstructionData()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        foreach (var data in sceneInstructions)
        {
            if (data.sceneName == sceneName)
            {
                currentSceneData = data;
                return;
            }
        }

        Debug.LogWarning("Tidak ada instruction data untuk scene: " + sceneName);
    }

    public void CompleteObjective()
    {
        currentObjective++;

        if (currentSceneData == null) return;

        if (currentObjective < currentSceneData.objectiveInstructions.Length)
        {
            ShowCurrentInstruction();
        }
        else
        {
            InstructionManager.Instance.ShowInstruction(
                currentSceneData.quizInstruction
            );

            QuizManager.Instance.ShowQuiz();
        }
    }

    void ShowCurrentInstruction()
    {
        if (currentSceneData == null) return;

        InstructionManager.Instance.ShowInstruction(
            currentSceneData.objectiveInstructions[currentObjective]
        );
    }
}
[System.Serializable]
public class SceneInstructionData
{
    public string sceneName;

    [TextArea]
    public string[] objectiveInstructions;

    [TextArea]
    public string quizInstruction;
}
