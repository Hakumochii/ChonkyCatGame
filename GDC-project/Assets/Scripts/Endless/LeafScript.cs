using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScript : MonoBehaviour
{
    [SerializeField] private GameObject roundLeaf;
    [SerializeField] private GameObject pointyLeaf;
    [SerializeField] private GameObject choiceTree;

    [SerializeField] private float[] pointyChance;
    [SerializeField] private float[] choiceChance;
    [SerializeField] private float[] pointsForChances;

    [SerializeField] private GameObject myTreeLog;

    // Start is called before the first frame update
    void Start()
    {
        int pointHitInt = 0;
        for (int i = 0; i < pointsForChances.Length; i++)
        {
            // Find point tracker and get its # of points, use this to assign pointhitintthing to i
            if (pointsForChances[i] <= GameObject.Find("PointTracker").GetComponent<PointScript>().points)
            {
                pointHitInt = i;
            }
        }

        // Checks for spawning choice trees and then pointy trees
        if (Random.value < choiceChance[pointHitInt])
        {
            Destroy(myTreeLog);
            Instantiate(choiceTree, transform);
        }
        else if (Random.value < pointyChance[pointHitInt])
        {
            Instantiate(pointyLeaf, transform);
        }
        else
        {
            Instantiate(roundLeaf, transform);
        }
    }
}
