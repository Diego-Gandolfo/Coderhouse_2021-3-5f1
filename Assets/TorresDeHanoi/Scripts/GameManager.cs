using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public HeadUpDisplay headUpDisplay;

    public int bestGame = int.MaxValue;
    public int movesCounter;

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
    }

    public void Restart()
    {
        headUpDisplay.InitializeHeadUpDisplay();
        TowersManager.Instance.InitializeTowers();
    }    

    public void IncreaseMovesCounter()
    {
        movesCounter++;
        headUpDisplay.UpdateMovesCounterText();
    }

    public void Victory()
    {
        if (movesCounter < bestGame)
        {
            bestGame = movesCounter;
            headUpDisplay.Victory(true);
        }
        else
        {
            headUpDisplay.Victory(false);
        }
    }
}
