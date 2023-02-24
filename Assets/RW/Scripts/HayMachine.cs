using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float horizontalBoundry = 22;
    [SerializeField] private GameObject hayBalePrefab;
    [SerializeField] private Transform haySpawnPoint;
    [SerializeField] private float shootInterval;
    private float shootTimer;

    private void Update()
    {
        UpdateMovement();
        UpdateShooting();
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

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnPoint.position, Quaternion.identity);
    }
}
