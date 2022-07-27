using System.Collections.Generic;
using UnityEngine;

public enum Location
{
    Left, Center, Right
}

public class TowersManager : MonoBehaviour
{
    public static TowersManager Instance;

    [SerializeField] private Block[] blocks;

    private bool isGameRunning;

    private Stack<Block> towerLeft = new Stack<Block>();
    private Stack<Block> towerCenter = new Stack<Block>();
    private Stack<Block> towerRight = new Stack<Block>();

    private Dictionary<Location, Stack<Block>> towers = new Dictionary<Location, Stack<Block>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager.Instance.movesCounter = 0;

        towers.Add(Location.Left, towerLeft);
        towers.Add(Location.Center, towerCenter);
        towers.Add(Location.Right, towerRight);

        InitializeTowers();
    }

    private void Update()
    {
        if (towerRight.Count == 4 && isGameRunning)
        {
            isGameRunning = false;
            GameManager.Instance.Victory();
        }
    }

    public void InitializeTowers()
    {
        isGameRunning = true;
        
        towerLeft.Clear();
        towerCenter.Clear();
        towerRight.Clear();

        foreach (Block block in blocks)
        {
            towerLeft.Push(block);
            float y = (towerLeft.Count / 2f);
            block.transform.localPosition = new Vector3(-6f, y, 0f);
        }
    }

    public void MoveBlock(Location origin, Location destination)
    {
        if (!CheckMoveBlock(origin, destination)) return;

        Stack<Block> towerOrigin = towers[origin];
        Stack<Block> towerDestination = towers[destination];
        
        int direction = ((int)destination - (int)origin);

        Block block = towerOrigin.Pop();
        towerDestination.Push(block);

        float x = block.transform.localPosition.x + (direction * 6f);
        float y = (towerDestination.Count / 2f);
        block.transform.localPosition = new Vector3(x, y, 0f);

        GameManager.Instance.IncreaseMovesCounter();
    }

    private bool CheckMoveBlock(Location origin, Location destination)
    {
        Stack<Block> towerOrigin = towers[origin];
        Stack<Block> towerDestination = towers[destination];

        if (towerOrigin.Count == 0) return false;
        if (towerDestination.Count == 0) return true;
        if (towerOrigin.Peek().weight > towerDestination.Peek().weight) return false;

        return true;
    }
}
