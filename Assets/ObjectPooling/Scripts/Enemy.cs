using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private Transform playerTransform;

    private void Start()
    {
        Player player = FindObjectOfType<Player>();
        playerTransform = player.transform;
    }

    private void Update()
    {
        MakeMovement();
        MakeRotation();
    }

    private void MakeMovement()
    {
        var distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance > 1f)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }

    private void MakeRotation()
    {
        var direction = playerTransform.position - transform.position;
        var wantedRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, rotationSpeed * Time.deltaTime);
    }
}
