using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    [Header("UI")]
    public GameObject quizPanel;
    public TextMeshProUGUI questionText;
    public Button[] optionButtons;

    [Header("Quiz Data (per Scene)")]
    public QuizQuestion[] questions;

    int currentQuestionIndex = 0;
    int correctCount = 0;

    void Awake()
    {
        Instance = this;
        quizPanel.SetActive(false);
    }

    public void ShowQuiz()
    {
        quizPanel.SetActive(true);
        currentQuestionIndex = 0;
        correctCount = 0;
        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex >= questions.Length)
        {
            FinishQuiz();
            return;
        }

        QuizQuestion q = questions[currentQuestionIndex];
        questionText.text = q.question;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;

            optionButtons[i]
                .GetComponentInChildren<TextMeshProUGUI>()
                .text = q.options[i];

            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => Answer(index));
        }
    }

    void Answer(int selectedIndex)
    {
        // ❌ salah → diam di soal ini
        if (selectedIndex != questions[currentQuestionIndex].correctIndex)
        {
            InstructionManager.Instance.ShowInstruction(
                "Jawaban salah, coba lagi."
            );
            return;
        }
    
        // ✅ benar
        correctCount++;
        currentQuestionIndex++;
    
        if (correctCount >= 3 || currentQuestionIndex >= questions.Length)
        {
            FinishQuiz();
        }
        else
        {
            ShowQuestion();
        }
    }


    void FinishQuiz()
    {
        quizPanel.SetActive(false);
    
        string sceneName = SceneManager.GetActiveScene().name;
    
        if (sceneName == "GedungPUT")
        {
            InstructionManager.Instance.ShowInstruction(
                "Kuis selesai.\nSelamat! Anda telah menyelesaikan game ini."
            );
        }
        else
        {
            InstructionManager.Instance.ShowInstruction(
                "Kuis selesai.\nAkses ke gedung berikutnya telah dibuka."
            );
    
            TeleportController.Instance.UnlockNext();
        }
    }

}
[System.Serializable]
public class QuizQuestion   
{
    public string question;
    public string[] options;
    public int correctIndex;
}