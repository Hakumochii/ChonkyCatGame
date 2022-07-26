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

    [SerializeField] private float maxAwayFromPrevTree = 8f;
    [SerializeField] private float maxZIfMaxX = 6f;
    [SerializeField] private float maxYIfMaxX = 1.5f;

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


        // Makes sure the tree hasn't moved too far
        if (xPlace > prevPos.x + maxAwayFromPrevTree)
        {
            xPlace = prevPos.x + maxAwayFromPrevTree;

            // Sets max Z and Y for this tree
            float thisMaxZ = maxZIfMaxX + prevPos.z;
            float thisMaxY = maxYIfMaxX + prevPos.y;

            if (height > thisMaxY)
            {
                height = thisMaxY;
            }

            if (distance > thisMaxZ)
            {
                distance = thisMaxZ;
            }
        }
        else if (xPlace < prevPos.x - maxAwayFromPrevTree)
        {
            xPlace = prevPos.x - maxAwayFromPrevTree;

            // Sets max Z and Y for this tree
            float thisMaxZ = maxZIfMaxX + prevPos.z;
            float thisMaxY = maxYIfMaxX + prevPos.y;

            if (height > thisMaxY)
            {
                height = thisMaxY;
            }

            if (distance > thisMaxZ)
            {
                distance = thisMaxZ;
            }
        }

        // Rotates the tree if it's close to the camera
        if (xPlace > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        transform.position = new Vector3(xPlace, height, distance);
    }
}
