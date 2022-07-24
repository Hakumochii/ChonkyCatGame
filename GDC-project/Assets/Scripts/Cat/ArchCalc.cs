using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchCalc : MonoBehaviour
{
    public float velocity = 0f;
    private float jumpAngle = 45f;
    [SerializeField] private Transform catTrans;

    // Start is called before the first frame update
    void Start()
    {
        jumpAngle = GameObject.FindWithTag("Player").GetComponent<CatJumpScript>().jumpAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity > 0f)
        {
            // Calculates the max x distance
            float maxX = -((velocity * velocity) * ((Mathf.Sin((-jumpAngle * Mathf.Deg2Rad) * 2)))) / 9.81f;
            Vector3 goalPosition = catTrans.position + catTrans.forward * maxX;
            goalPosition.y = 0;
            transform.localPosition = goalPosition;
        }
    }
}
