using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollect : MonoBehaviour
{
    [SerializeField] private PointScript pointCounter;
    private bool hasJustCollectedFish = false;
    private float waitTimeForNextFish = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasJustCollectedFish && waitTimeForNextFish <= 0f)
        {
            waitTimeForNextFish = 0.3f;
            hasJustCollectedFish = false;
            pointCounter.AddPoints(5);
        }
        else if (waitTimeForNextFish > 0f)
        {
            waitTimeForNextFish -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish")
        {
            Destroy(other.transform.parent.gameObject);
            hasJustCollectedFish = true;
        }
    }
}
