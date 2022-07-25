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
        InitializeSingleton();
    }

    private void Start()
    {
        InitializeDictionary();
        InitializeTowers();
    }

    private void Update()
    {
        CheckVictory();
    }

    private void InitializeSingleton()
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

    private void InitializeDictionary()
    {
        towers.Add(Location.Left, towerLeft);
        towers.Add(Location.Center, towerCenter);
        towers.Add(Location.Right, towerRight);
    }

    private void InitializeTowers()
    {
        isGameRunning = true;
        
        towerLeft.Clear();
        towerCenter.Clear();
        towerRight.Clear();

        foreach (Block block in blocks)
        {
            towerLeft.Push(block);
            var y = (towerLeft.Count / 2f);
            block.transform.localPosition = new Vector3(-6f, y, 0f);
        }
    }

    private void CheckVictory()
    {
        if (towerRight.Count == 4 && isGameRunning)
        {
            isGameRunning = false;
            GameManager.Instance.Victory();
        }
    }

    private bool CheckMoveBlock(Location origin, Location destination)
    {
        var towerOrigin = towers[origin];
        var towerDestination = towers[destination];

        if (towerOrigin.Count == 0) return false;
        if (towerDestination.Count == 0) return true;
        if (towerOrigin.Peek().GetWeight() > towerDestination.Peek().GetWeight()) return false;

        return true;
    }

    public void MoveBlock(Location origin, Location destination)
    {
        if (!CheckMoveBlock(origin, destination)) return;

        var towerOrigin = towers[origin];
        var towerDestination = towers[destination];
        var direction = ((int)destination - (int)origin);

        var block = towerOrigin.Pop();
        towerDestination.Push(block);

        var x = block.transform.localPosition.x + (direction * 6f);
        var y = (towerDestination.Count / 2f);
        block.transform.localPosition = new Vector3(x, y, 0f);

        GameManager.Instance.IncreaseMovesCounter();
    }

    public void InitializeTowersManager()
    {
        InitializeTowers();
    }
}
