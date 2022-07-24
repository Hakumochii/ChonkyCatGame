using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDeathSpawn : MonoBehaviour
{
    [SerializeField] private TreeDeathSpawn spawnedTreesScript;

    [SerializeField] private GameObject[] treePrefabs;

    [SerializeField] private float spawnDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Once behind the camera, destroy self
        if (Camera.main.transform.position.z > transform.position.z + 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Tell the next tree to spawn a tree<s
        spawnedTreesScript.GoSpawn();
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
            // Gets location X meters ahead
            Vector3 newSpawnPos = transform.position + new Vector3(0f, 0f, spawnDistance);

            // Spawns new tree X meters ahead and remembers its script
            spawnedTreesScript = Instantiate(treePrefabs[Mathf.FloorToInt(Random.Range(0f, treePrefabs.Length))], newSpawnPos, Quaternion.identity).GetComponent<TreeDeathSpawn>();

            spawnedTreesScript.gameObject.GetComponent<TreeJustSpawned>().JustSpawned(transform.position.y);
        }
    }
}
