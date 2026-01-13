using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        // pastikan XR Origin
        if (!other.transform.root.name.Contains("XR Origin"))
            return;

        triggered = true;

        // hancurkan pointer
        Destroy(gameObject);

        // munculkan quiz
        if (QuizManager.Instance != null)
        {
            QuizManager.Instance.ShowQuiz();
        }
    }
}
