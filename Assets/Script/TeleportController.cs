using UnityEngine;

public class TeleportController : MonoBehaviour
{

    public bool isLocked = true;

    public void LockTeleport()
    {
        isLocked = true;
    }

    public void UnlockTeleport()
    {
        isLocked = false;
    }

    public void TryTeleport(System.Action teleportAction)
    {
        if (isLocked)
        {
            InstructionManager.Instance.ShowInstruction(
            "Selesaikan objektif saat ini sebelum berpindah ke area berikutnya."
            );
            return;
        }

        teleportAction.Invoke();
    }

    void Start()
{
    if (GameManager.Instance.currentMode == GameMode.FreeRoam)
    {
        UnlockTeleport(); // semua bebas
    }
    else
    {
        LockTeleport();   // ikut quest
    }
}
}
