using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab; // TODO: usar Object Pooling

    private void OnCollisionEnter(Collision collision)
    {
        Explote();
    }

    private void Explote()
    {
        Instantiate(effectPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
