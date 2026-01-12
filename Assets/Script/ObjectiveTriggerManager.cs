using UnityEngine;
using System.Collections.Generic;

public class ObjectiveTriggerManager : MonoBehaviour
{
    [System.Serializable]
    public class ObjectiveGroup
    {
        public List<Collider> triggers; // sub-trigger
    }

    public List<ObjectiveGroup> objectives = new List<ObjectiveGroup>();

    private HashSet<Collider> triggered = new HashSet<Collider>();

    void Start()
    {
        // pastikan semua collider adalah trigger
        foreach (var obj in objectives)
        {
            foreach (var col in obj.triggers)
            {
                col.isTrigger = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 🔍 debug
        Debug.Log("Trigger masuk oleh: " + other.name);

        // Free roam → abaikan
        if (GameManager.Instance != null &&
            GameManager.Instance.currentMode == GameMode.FreeRoam)
            return;

        // pastikan XR Origin
        if (!other.transform.root.name.Contains("XR Origin"))
            return;

        int currentObjective = QuestManager.Instance.currentObjective;

        if (currentObjective >= objectives.Count)
            return;

        // cek apakah collider ini bagian dari objektif aktif
        if (!objectives[currentObjective].triggers.Contains(other))
            return;

        // sudah pernah kena
        if (triggered.Contains(other))
            return;

        triggered.Add(other);
        other.enabled = false;

        // cek apakah semua sub-trigger objektif ini sudah kena
        foreach (var col in objectives[currentObjective].triggers)
        {
            if (!triggered.Contains(col))
                return;
        }

        // ✅ objektif selesai
        QuestManager.Instance.CompleteObjective();
    }
}
