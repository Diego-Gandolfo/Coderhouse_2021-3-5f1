using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public HeadUpDisplay headUpDisplay;

    private float currentTime;
    public float bestTime;

    public bool isGameRunning;

    private void Awake()
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

        isGameRunning = false;
        bestTime = float.MaxValue;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            currentTime += Time.deltaTime;
            headUpDisplay.UpdateTime(currentTime);
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        isGameRunning = true;
        currentTime = 0f;
    }

    public void Gameover()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        isGameRunning = false;

        if (bestTime > currentTime)
        {
            bestTime = currentTime;
            headUpDisplay.Victory(currentTime, true);
        }
        else
        {
            headUpDisplay.Victory(currentTime);
        }
    }
}
