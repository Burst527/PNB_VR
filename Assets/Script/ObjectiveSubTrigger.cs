using UnityEngine;

public class ObjectiveSubTrigger : MonoBehaviour
{
    private bool triggered = false;
    private ObjectiveTrigger parent;

    void Awake()
    {
        parent = GetComponentInParent<ObjectiveTrigger>();

        if (parent == null)
            Debug.LogError($"ObjectiveTrigger parent TIDAK ditemukan di {name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (GameManager.Instance != null &&
            GameManager.Instance.currentMode == GameMode.FreeRoam)
            return;

        if (!other.transform.root.name.Contains("XR Origin"))
            return;

        triggered = true;
        GetComponent<Collider>().enabled = false;

        gameObject.SetActive(false);
        
        parent.NotifySubTriggered(this);
    }
}
