using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    // Move towards positive Z over time
    public float moveSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.forward * moveSpeed * Time.deltaTime;
    }
}
