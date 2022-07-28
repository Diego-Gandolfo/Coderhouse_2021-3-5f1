using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float life;

    private Rigidbody myRigidbody;

    private Vector3 wantedDirection;
    private Vector3 wantedRotation;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CheckInputs();
        MakeRotation();
    }

    private void FixedUpdate()
    {
        MakeMovement();
    }

    private void CheckInputs()
    {
        var x = Input.GetAxisRaw("Horizontal") * transform.right;
        var z = Input.GetAxisRaw("Vertical") * transform.forward;
        wantedDirection = x + z;

        var y = Input.GetAxis("Mouse X");
        wantedRotation = new Vector3(0f, y, 0f);
    }

    private void MakeMovement()
    {
        myRigidbody.velocity = wantedDirection * movementSpeed;

    }

    private void MakeRotation()
    {
        transform.Rotate(wantedRotation * rotationSpeed * Time.deltaTime);
    }

    public void MakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0f)
        {
            GameManager.Instance.Gameover();
        }
    }
}
