using UnityEngine;

public class LevelNumberPasser : MonoBehaviour
{
    public static LevelNumberPasser Instance { get; private set; }

    private static int _levelNumber;

    public static int LevelNumber => _levelNumber;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public static void SetLevelNumber(int levelNumber)
    {
        _levelNumber = levelNumber;
    }
}
