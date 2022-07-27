using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishyPrefab;
    private GameObject myFishy;

    [SerializeField] private float fishChance = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // If random value is less than fish chance
        if (Random.value <= fishChance)
        {
            // Spawn fish and place it somewhere random on the leaf
            myFishy = Instantiate(fishyPrefab, transform);
        }
    }

    // Destroys fish before death to avoid the duplication thingy thing
    private void OnDestroy()
    {
        Destroy(myFishy);
    }
}
