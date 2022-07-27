using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpin : MonoBehaviour
{
    [SerializeField] private float timeyScaley = 180f;
    [SerializeField] private float moveScale = 1f;
    [SerializeField] private float rotationScale = 10f;
    private float myTimeFloatSpin = 0f;

    // Update is called once per frame
    void Update()
    {
        myTimeFloatSpin += Time.deltaTime;
        transform.Translate(0f, Mathf.Sin(myTimeFloatSpin * timeyScaley) * moveScale, 0f);
        transform.rotation = Quaternion.Euler(0f, myTimeFloatSpin * rotationScale, 0f);
    }
}
