using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameMode currentMode = GameMode.Guided;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
public enum GameMode
{
    Guided,
    FreeRoam
}