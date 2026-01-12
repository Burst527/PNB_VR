using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.currentMode == GameMode.FreeRoam)
    {
        gameObject.SetActive(false);
        return;
    }
        if (hasTriggered) return;
        if (!other.CompareTag("Player")) return;

        hasTriggered = true;
        GetComponent<Collider>().enabled = false;
        QuestManager.Instance.CompleteObjective();
        
    }
}
