using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private float timeToDeactivate = 2.0f;

    private float timeCounter;

    private void Start()
    {
        timeCounter = timeToDeactivate;
    }

    private void Update()
    {
        Timer();
    }
    
    private void Timer()
    {
        timeCounter -= Time.deltaTime;

        if (timeCounter <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
