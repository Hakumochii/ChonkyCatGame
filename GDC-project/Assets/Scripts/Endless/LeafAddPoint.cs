using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafAddPoint : MonoBehaviour
{
    [SerializeField] private int pointAmount = 1;
    private bool hasBeenTouched = false;

    public void AddPoints()
    {
        if (!hasBeenTouched)
        {
            GameObject.Find("PointTracker").GetComponent<PointScript>().AddPoints(pointAmount);
            hasBeenTouched = true;
        }
    }
}
