using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private float timeToDeactivate = 2.0f;
    [SerializeField] private ParticleSystem effect;

    private float timeCounter;

    private void Start()
    {
        Initialize();
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

    public void Initialize()
    {
        timeCounter = timeToDeactivate;
        effect.Play();
    }
}
