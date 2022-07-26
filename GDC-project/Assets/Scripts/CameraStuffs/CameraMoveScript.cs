using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    // For making sure camera isn't too far behind
    private Transform catTrans;

    // Move towards positive Z over time
    public float horiMoveSpeed = 1.5f;
    public float vertiMoveSpeed = 0.5f;

    // The used values, tweaked from above
    public float tempVertiSpeed;

    [SerializeField] private float horiDistance = 4;
    [SerializeField] private float vertiDistance = 4;

    public bool beginMovement = false;

    private void Start()
    {
        catTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginMovement)
        {
            float tempHoriSpeed = horiMoveSpeed;

            if (catTrans.position.y - transform.position.y > vertiDistance)
            {
                // Multiplier calc
                float distanceMultiplier = catTrans.position.z - vertiDistance - transform.position.z + 1;
                // Set the speed
                tempVertiSpeed = vertiMoveSpeed * distanceMultiplier;
            }
            else if (catTrans.position.y - transform.position.y < -1)
            {
                tempVertiSpeed = 0;
            }
            
            if (catTrans.position.z - transform.position.z > horiDistance)
            {
                float distanceMultiplier = catTrans.position.z - 4 - transform.position.z + 1;
                tempHoriSpeed = horiMoveSpeed * distanceMultiplier;
            }

            if (tempVertiSpeed < 0)
            {
                tempVertiSpeed = 0;
            }

            transform.Translate(Vector3.forward * tempHoriSpeed * Time.deltaTime + Vector3.up * tempVertiSpeed * Time.deltaTime);
        }
    }
}
