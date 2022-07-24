using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDeathSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] treePrefabs;

    [SerializeField] private float spawnDistance = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.z > transform.position.z)
        {
            // Gets location X meters ahead
            Vector3 newSpawnPos = transform.position + new Vector3(0f, 0f, spawnDistance);

            GameObject newTree = Instantiate(treePrefabs[int(Random.Range(0f, treePrefabs.Length))], transform.position)
            Destroy(gameObject);
        }
    }
}
