using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchCalc : MonoBehaviour
{
    private float jumpAngle = 45f;
    [SerializeField] private Transform catTrans;

    [SerializeField] private LayerMask[] layersToRay;
    private LineRenderer theAdventureLine;
    [SerializeField] private int numOfPointsInArch = 20;

    [SerializeField] private float yDeposition = -0.58f;

    // Start is called before the first frame update
    void OnEnable()
    {
        // Finds the line renderer and sets the amount of positions
        theAdventureLine = GetComponent<LineRenderer>();
        theAdventureLine.positionCount = numOfPointsInArch;

        jumpAngle = GameObject.FindWithTag("Player").GetComponent<CatJumpScript>().jumpAngle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when asked to draw. aka when charging jump
    public void DrawThis(float velocity)
    {
        // This part calculates the max X distance
        // Calculates the max x distance
        float maxX = -((velocity * velocity) * ((Mathf.Sin((-jumpAngle * Mathf.Deg2Rad) * 2)))) / 9.81f;

        // This part moves something to the end point of the jump arch
        /*
        goalPosition.y = catTrans.position.y - 0.58f;
        transform.localPosition = goalPosition;
        */

        // This part would draw an arch

        // It draws the line through the arch by finding 50 points
        for (int i = 0; i < numOfPointsInArch; i++)
        {
            // Gets the goal part of the X (like 1/20th, up to 20/20th)
            float currentX = (i + 1) * maxX / numOfPointsInArch;

            // Calculates the y position of a given point on the parabola
            // Follows y = -(g / (2 * v^2 * (cos(a))) * x^2 + tan(a) * x + y
            float thisYPos = -(9.82f / (2 * velocity * velocity * (Mathf.Cos(jumpAngle * Mathf.Deg2Rad)) * (Mathf.Cos(jumpAngle * Mathf.Deg2Rad)))) * currentX * currentX + Mathf.Tan(jumpAngle * Mathf.Deg2Rad) * currentX + transform.position.y;

            Vector3 goalPosition = catTrans.position + catTrans.forward * currentX;
            goalPosition.y = thisYPos + catTrans.position.y + yDeposition;

            if (theAdventureLine.gameObject.activeSelf)
            {
                theAdventureLine.SetPosition(i, goalPosition);
            }
        }
    }
}
