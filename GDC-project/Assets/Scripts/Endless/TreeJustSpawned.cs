using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeJustSpawned : MonoBehaviour
{
    [SerializeField] private float leafRiseMin = 1f;
    [SerializeField] private float leafRiseMax = 2.5f;

    [SerializeField] private float minXPlace = -15f;
    [SerializeField] private float maxXPlace = 2f;

    [SerializeField] private float distanceMin = 5f;
    [SerializeField] private float distanceMax = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JustSpawned(Vector3 prevPos)
    {
        // Spawn at a randomized height, length and position
        float xPlace = Random.Range(minXPlace, maxXPlace);
        float height = prevPos.y + Random.Range(leafRiseMin, leafRiseMax);
        float distance = prevPos.z + Random.Range(distanceMin, distanceMax);

        transform.position = new Vector3(xPlace, height, distance);
    }
}
