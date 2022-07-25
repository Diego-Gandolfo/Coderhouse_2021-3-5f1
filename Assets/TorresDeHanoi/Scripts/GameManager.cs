using System.Collections;
using System.Collections.Generic;
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
    }

    public void Restart()
    {
        //TowersManager.Instance.Initialize();
        HUDManager.Instance.Initialize();
        TowersManager.Instance.InitializeT();
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

    }

    public void Gameover()
    {

    }
}
