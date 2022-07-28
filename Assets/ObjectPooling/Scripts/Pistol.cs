using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // TODO: usar Object Pooling
    [SerializeField] private Transform bulletSpawnpoint;

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MakeShoot();
        }
    }

    private void MakeShoot()
    {
        Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
    }
}
