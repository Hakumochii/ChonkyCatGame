using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyLeafEnemy : MonoBehaviour
{
    [SerializeField] private GameObject crowEnemy;
    private GameObject myEnemy;

    // Start is called before the first frame update
    void Start()
    {
        myEnemy = Instantiate(crowEnemy, transform);

        float xCoord = Random.Range(-0.5f, 0.5f);

        float zCoord = FindZByX(xCoord);

        myEnemy.transform.localPosition = new Vector3(xCoord, 0.5f, zCoord);
    }

    private float FindZByX(float xCoord)
    {
        float endFloat = 0;

        // Do linear equation to find the max X
        if (xCoord >= 0)
        {
            endFloat = -xCoord * 0.5f + 0.5f;
        }
        else
        {
            endFloat = xCoord * 0.5f + 0.5f;
        }

        // Choose a random point within the range
        endFloat = Random.Range(-endFloat, endFloat);

        return endFloat;
    }

    // Destroys enemy before death to avoid the duplication thingy thing
    private void OnDestroy()
    {
        Destroy(myEnemy);
    }
}
