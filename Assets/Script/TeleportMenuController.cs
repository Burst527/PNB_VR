using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TeleportMenuController : MonoBehaviour
{
    [System.Serializable]
    public class TeleportButton
    {
        public Button button;
        public TeleportType type;
        public string targetScene;
    }

    public enum TeleportType
    {
        Reset,
        Next,
        Free
    }

    [Header("Teleport Buttons")]
    public List<TeleportButton> teleportButtons;

    void Start()
    {
        foreach (var tp in teleportButtons)
        {
            // tp.button.onClick.RemoveAllListeners();
            tp.button.onClick.AddListener(() => HandleTeleport(tp));

            // 🔵 MODE GUIDED
            if (GameManager.Instance.currentMode == GameMode.Guided)
            {
                if (tp.type == TeleportType.Free)
                {
                    tp.button.gameObject.SetActive(false);
                }


                //HIDE TOMBOL NEXT
                // if (tp.type == TeleportType.Next &&
                //     TeleportController.Instance.isNextLocked)
                // {
                //     tp.button.gameObject.SetActive(false);
                // }
            }
        }
    }

    void HandleTeleport(TeleportButton tp)
    {
        if (TeleportController.Instance == null)
        {
            Debug.LogError("TeleportController.Instance NULL");
            return;
        }

        switch (tp.type)
        {
            case TeleportType.Next:
                if (TeleportController.Instance.isNextLocked &&
                    GameManager.Instance.currentMode == GameMode.Guided)
                {
                    InstructionManager.Instance.ShowInstruction(
                        "Selesaikan objektif terlebih dahulu."
                    );
                    return;
                }
                SceneManager.LoadScene(tp.targetScene);
                break;

            case TeleportType.Free:
                SceneManager.LoadScene(tp.targetScene);
                break;

            case TeleportType.Reset:
                SceneManager.LoadScene(tp.targetScene);
                break;
        
        }
    }

}
