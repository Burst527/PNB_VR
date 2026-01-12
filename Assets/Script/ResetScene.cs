using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetScene;

    [Header("Teleport Rule")]
    public bool isNextBuilding; // ✔ centang hanya untuk tombol NEXT

    public void SwitchScene()
    {
        // reload selalu boleh
        if (SceneManager.GetActiveScene().name == targetScene)
        {
            SceneManager.LoadScene(targetScene);
            return;
        }

        // cek hanya untuk tombol NEXT GEDUNG
        if (isNextBuilding &&
            TeleportController.Instance != null &&
            TeleportController.Instance.isNextLocked)
        {
            InstructionManager.Instance.ShowInstruction(
                "Selesaikan objektif dan kuis terlebih dahulu."
            );
            return;
        }

        SceneManager.LoadScene(targetScene);
    }
}
