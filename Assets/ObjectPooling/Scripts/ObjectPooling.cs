using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private Queue<GameObject> availableInstances = new Queue<GameObject>();
    private List<GameObject> inUseInstances = new List<GameObject>();

    public GameObject GetInstance()
    {
        GameObject clone;

        if (availableInstances.Count > 0)
        {
            clone = availableInstances.Dequeue();
        }
        else
        {
            clone = Instantiate(prefab);
        }

        inUseInstances.Add(clone);
        clone.SetActive(true);
        return clone;
    }

    public void StoreInstance(GameObject clone)
    {
        inUseInstances.Remove(clone);
        availableInstances.Enqueue(clone);
        clone.SetActive(false);
    }
}
