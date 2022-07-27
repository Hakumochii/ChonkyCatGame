using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private Transform camMovement;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.up * camMovement.position.y;
    }
}
