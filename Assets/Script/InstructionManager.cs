using UnityEngine;
using TMPro;
using System.Collections;

public class InstructionManager : MonoBehaviour
{
    public static InstructionManager Instance;

    public GameObject panel;
    public TextMeshProUGUI instructionText;
    public float showDuration = 4f;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void ShowInstruction(string message)
    {   
        if (GameManager.Instance.currentMode == GameMode.FreeRoam)
        {  
            panel.SetActive(false);
            return;
        }

        StopAllCoroutines();
        panel.SetActive(true);
        instructionText.text = message;

        PositionInFrontOfPlayer();
        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(showDuration);
        panel.SetActive(false);
    }

    void PositionInFrontOfPlayer()
    {
        Transform cam = Camera.main.transform;
        transform.position = cam.position + cam.forward * 2.5f;
        transform.LookAt(cam);
        transform.Rotate(0, 180, 0);
    }
}
