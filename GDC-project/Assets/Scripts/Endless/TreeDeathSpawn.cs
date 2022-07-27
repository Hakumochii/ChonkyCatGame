using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TreeDeathSpawn : MonoBehaviour
{
    [SerializeField] private bool firstTree = false;

    [SerializeField] private GameObject spawnedTree;

    [SerializeField] private Object treePrefab;

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
            // Tell the next tree to spawn a tree
            spawnedTree.GetComponent<TreeDeathSpawn>().GoSpawn();
            Destroy(gameObject);
        }
    }

    public void GoSpawn()
    {
        // If this has spawned a tree, tell that tree to spawn one
        if (spawnedTree != null)
        {
            spawnedTree.GetComponent<TreeDeathSpawn>().GoSpawn();
        } // If haven't spawned a tree, spawn one
        else
        {
            // If this is within a certain distance of the camera
            if (transform.position.z - Camera.main.transform.position.z < 90f)
            {
                // Gets location X meters ahead
                Vector3 newSpawnPos = transform.position + new Vector3(0f, 0f, spawnDistance);

                Debug.Log("I am " + gameObject + " and I shall spawn now");

                // Spawns new tree X meters ahead and remembers its script
                spawnedTree = PrefabUtility.InstantiatePrefab(treePrefab as GameObject) as GameObject;

                Debug.Log("I am " + gameObject + " and I have " + spawnedTree + " as SpawnedTree");

                Debug.Log("I am " + gameObject + " and I have the JustSpawned script: " + spawnedTree.GetComponent<TreeJustSpawned>());

                Debug.Log("I am " + gameObject + " and I have the DeathSpawn script: " + spawnedTree.GetComponent<TreeDeathSpawn>());

                // Tells new tree to get a position and where this tree was
                spawnedTree.GetComponent<TreeJustSpawned>().JustSpawned(transform.position);

                Debug.Log("I am " + gameObject + " and TreeJustSpawned have been initiated");

                // Spawn another tree further along
                spawnedTree.GetComponent<TreeDeathSpawn>().GoSpawn();

                Debug.Log("I am " + gameObject + " and I just told " + spawnedTree + " to spawn a tree");
            }
        }
    }
}
