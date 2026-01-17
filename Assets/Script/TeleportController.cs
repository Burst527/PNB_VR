using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public static TeleportController Instance;

    [Tooltip("Apakah teleport ke gedung berikutnya masih terkunci")]
    public bool isNextLocked = true;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (GameManager.Instance.currentMode == GameMode.FreeRoam)
        {
            isNextLocked = false; // bebas
        }else
        {
            isNextLocked = true; // terkunci di mode objektif
        }
    }

    public void UnlockNext()
    {
        isNextLocked = false;
    }
}
