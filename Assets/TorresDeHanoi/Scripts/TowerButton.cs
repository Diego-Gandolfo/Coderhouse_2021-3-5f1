using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private Location origin;
    [SerializeField] private Location destination;

    public void CallMoveBlock()
    {
        TowersManager.Instance.MoveBlock(origin, destination);
    }
}
