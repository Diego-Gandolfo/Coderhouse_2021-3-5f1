using System.Collections;
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
        towers.Add(Location.Left, towerLeft);
        towers.Add(Location.Center, towerCenter);
        towers.Add(Location.Right, towerRight);

        InitializeT();
    }

    public void InitializeT()
    {
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

    public void MoveBlock(Location origin, Location destination)
    {
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
}
