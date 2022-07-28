using UnityEngine;

public class EnemyExplote : MonoBehaviour
{
    [SerializeField] private float timeToDeactivate;

    private float timeCounter;

    private void Update()
    {

        RunTimer();

    }

    private void RunTimer()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= timeToDeactivate)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
