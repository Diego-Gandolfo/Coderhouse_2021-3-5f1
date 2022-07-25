using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int movesCounter;
    private int bestGame;

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

        bestGame = int.MaxValue;
    }

    public int GetBestGameInfo()
    {
        return bestGame;
    }

    public void ResetMovesCounter()
    {
        movesCounter = 0;
    }

    public void Restart()
    {
        ResetMovesCounter();
        HUDManager.Instance.InitializeHUDManager();
        TowersManager.Instance.InitializeTowersManager();
    }    

    public void IncreaseMovesCounter()
    {
        movesCounter++;
        HUDManager.Instance.UpdateMovesCounterText();
    }

    public int GetMovesCounterInfo()
    {
        return movesCounter;
    }

    public void Victory()
    {
        if (movesCounter < bestGame)
        {
            bestGame = movesCounter;
            HUDManager.Instance.Victory(true);
        }
        else
        {
            HUDManager.Instance.Victory(false);
        }
    }
}
