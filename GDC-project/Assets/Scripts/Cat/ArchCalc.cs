using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchCalc : MonoBehaviour
{
    public float velocity = 0f;
    [SerializeField] private float jumpAngle = 45f;
    [SerializeField] private Transform catTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity > 0f)
        {
            // Calculates the max x distance
            float maxX = -((velocity * velocity) * ((Mathf.Sin((-jumpAngle * Mathf.Deg2Rad) * 2)))) / 9.81f;
            transform.localPosition = new Vector3(0f, 0f, catTrans.position.z + maxX);
        }
    }
}
