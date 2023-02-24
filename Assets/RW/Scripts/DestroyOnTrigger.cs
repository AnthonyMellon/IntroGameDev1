using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    [SerializeField] private string tagFilter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagFilter))
        {
            Destroy(gameObject);
        }    
    }
}
