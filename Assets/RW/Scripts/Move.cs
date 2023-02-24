using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 movementSpeed;
    [SerializeField] private Space space;

    private void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }

}
