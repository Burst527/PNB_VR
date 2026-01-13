using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("Quest Progress")]
    public int currentObjective = 0;

    [Header("Scene Instructions")]
    public SceneInstructionData[] sceneInstructions;
    
    [Header("Quest Pointers (Optional)")]
    public ObjectivePointerData[] objectivePointers;

    [Header("Quiz Pointer")]
    public GameObject quizPointer;


    SceneInstructionData currentSceneData;

    void Awake()
    {
        Instance = this;

        if (GameManager.Instance != null &&
            GameManager.Instance.currentMode == GameMode.FreeRoam)
        {
            ForceDisableAllPointers();
        }
    }


    void Start()
    {
        if (GameManager.Instance.currentMode == GameMode.FreeRoam)
        {
            gameObject.SetActive(false);
            return;
        }

        ForceDisableAllPointers();

        LoadSceneInstructionData();
        ShowCurrentInstruction();

        ActivatePointersForObjective(currentObjective);
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
        DestroyPointersForObjective(currentObjective);
        currentObjective++;

        if (currentSceneData == null) return;

        if (currentObjective < currentSceneData.objectiveInstructions.Length)
        {
            ShowCurrentInstruction();

            ActivatePointersForObjective(currentObjective);
        }
        else
        {
            InstructionManager.Instance.ShowInstruction(
                currentSceneData.quizInstruction
            );

            if (quizPointer != null)
                quizPointer.SetActive(true);
        }
    }

    void ShowCurrentInstruction()
    {
        if (currentSceneData == null) return;

        InstructionManager.Instance.ShowInstruction(
            currentSceneData.objectiveInstructions[currentObjective]
        );
    }

    void ActivatePointersForObjective(int index)
    {
        if (objectivePointers == null || index >= objectivePointers.Length)
            return;

        var data = objectivePointers[index];

        if (data.mainPointer != null)
            data.mainPointer.SetActive(true);

        if (data.subQuestPointers != null)
        {
            foreach (var p in data.subQuestPointers)
            {
                if (p != null)
                    p.SetActive(true);
            }
        }
    }

    void DestroyPointersForObjective(int index)
    {
        if (objectivePointers == null || index >= objectivePointers.Length)
            return;

        var data = objectivePointers[index];

        if (data.mainPointer != null)
            Destroy(data.mainPointer);

        if (data.subQuestPointers != null)
        {
            foreach (var p in data.subQuestPointers)
            {
                if (p != null)
                    Destroy(p);
            }
        }
    }

    void ForceDisableAllPointers()
    {
        if (objectivePointers != null)
        {
            foreach (var data in objectivePointers)
            {
                if (data.mainPointer != null)
                    data.mainPointer.SetActive(false);

                if (data.subQuestPointers != null)
                {
                    foreach (var p in data.subQuestPointers)
                    {
                        if (p != null)
                            p.SetActive(false);
                    }
                }
            }
        }

        if (quizPointer != null)
            quizPointer.SetActive(false);
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

[System.Serializable]
public class ObjectivePointerData
{
    public GameObject mainPointer;           // pointer utama
    public GameObject[] subQuestPointers;     // optional
}