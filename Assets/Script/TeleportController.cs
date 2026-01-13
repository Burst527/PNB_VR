using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public static TeleportController Instance;

    [Tooltip("Apakah teleport ke gedung berikutnya masih terkunci")]
    public bool isNextLocked = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (GameManager.Instance.currentMode == GameMode.FreeRoam)
        {
            isNextLocked = false; // bebas
        }
    }

    public void UnlockNext()
    {
        isNextLocked = false;
    }
}
