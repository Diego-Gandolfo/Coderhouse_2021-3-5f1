using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int weight;
    
    public int GetWeight()
    {
        return weight;
    }
}
