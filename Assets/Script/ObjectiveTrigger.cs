using UnityEngine;
using System.Collections.Generic;

public class ObjectiveTrigger : MonoBehaviour
{
    private List<ObjectiveSubTrigger> subTriggers;
    private int triggeredCount = 0;
    private bool completed = false;

    void Awake()
    {
        subTriggers = new List<ObjectiveSubTrigger>(
            GetComponentsInChildren<ObjectiveSubTrigger>(true)
        );

        if (subTriggers.Count == 0)
        {
            Debug.LogError($"[ObjectiveTrigger] Tidak ada sub trigger di {name}");
        }
    }

    public void NotifySubTriggered(ObjectiveSubTrigger sub)
    {
        if (completed) return;

        triggeredCount++;

        Debug.Log($"Sub trigger kena ({triggeredCount}/{subTriggers.Count}) di {name}");

        if (triggeredCount >= subTriggers.Count)
        {
            CompleteObjective();
        }
    }

    private void CompleteObjective()
    {
        completed = true;
        Debug.Log($"OBJECTIVE COMPLETE: {name}");

        if (QuestManager.Instance != null)
            QuestManager.Instance.CompleteObjective();

        gameObject.SetActive(false);
    }
}
