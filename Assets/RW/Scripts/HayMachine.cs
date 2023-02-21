using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float horizontalBoundry = 22;

    private void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundry)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }

        if (horizontalInput > 0 && transform.position.x < horizontalBoundry)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }
}
