using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float gotHayDestroyDelay;
    private bool hitByHay;
    private bool dropped;
    [SerializeField] private float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;

        Destroy(gameObject, gotHayDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }

    private void Drop()
    {
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
