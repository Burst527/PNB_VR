using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public int currentObjective = 0;
    public int maxObjective = 3;

    public bool IsQuestCompleted()
    {
        return currentObjective >= maxObjective;
    }


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
        InstructionManager.Instance.ShowInstruction(
            "Selamat datang.\nJelajahi lantai pertama Gedung D4."
        );
    }

    public void CompleteObjective()
    {
        currentObjective++;

        if (currentObjective < maxObjective)
        {
            InstructionManager.Instance.ShowInstruction(
                "Objektif selesai.\nLanjutkan ke lantai berikutnya."
            );
        }
        else
        {
            InstructionManager.Instance.ShowInstruction(
                "Semua area telah dijelajahi.\nSilakan jawab kuis."
            );

            // aktifkan quiz
            QuizManager.Instance.ShowQuiz();
        }
    }
}
