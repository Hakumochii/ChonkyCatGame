using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    // Move towards positive Z over time
    public float horiMoveSpeed = 1.5f;
    public float vertiMoveSpeed = 0.5f;

    public bool beginMovement = false;

    // Update is called once per frame
    void Update()
    {
        if (beginMovement)
        {
            transform.Translate(Vector3.forward * horiMoveSpeed * Time.deltaTime + Vector3.up * vertiMoveSpeed * Time.deltaTime);
        }
    }
}
