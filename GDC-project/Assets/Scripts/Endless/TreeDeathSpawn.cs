using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDeathSpawn : MonoBehaviour
{
    [SerializeField] private bool firstTree = false;

    [SerializeField] private TreeDeathSpawn spawnedTreesScript;

    [SerializeField] private GameObject[] treePrefabs;

    [SerializeField] private float spawnDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (firstTree)
        {
            GoSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Once behind the camera, destroy self
        if (Camera.main.transform.position.z > transform.position.z + 10)
        {
            Debug.Log("Tree destroys self");
            // Tell the next tree to spawn a tree
            spawnedTreesScript.GoSpawn();
            Destroy(gameObject);
        }
    }

    public void GoSpawn()
    {
        // If this has spawned a tree, tell that tree to spawn one
        if (spawnedTreesScript != null)
        {
            spawnedTreesScript.GoSpawn();
        } // If haven't spawned a tree, spawn one
        else
        {
            // If this is within a certain distance of the camera
            if (transform.position.z - Camera.main.transform.position.z < 90f)
            {
                // Gets location X meters ahead
                Vector3 newSpawnPos = transform.position + new Vector3(0f, 0f, spawnDistance);

                // Spawns new tree X meters ahead and remembers its script
                spawnedTreesScript = Instantiate(treePrefabs[Mathf.FloorToInt(Random.Range(0f, treePrefabs.Length))], newSpawnPos, Quaternion.identity).GetComponent<TreeDeathSpawn>();

                spawnedTreesScript.gameObject.GetComponent<TreeJustSpawned>().JustSpawned(transform.position);

                // Spawn another tree further along
                spawnedTreesScript.GoSpawn();
            }
        }
    }
}
