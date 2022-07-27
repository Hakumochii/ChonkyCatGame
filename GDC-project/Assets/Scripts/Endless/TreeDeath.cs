using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDeath : MonoBehaviour
{
    public NewTreeSpawn treeSpawner;

    // Update is called once per frame
    void Update()
    {
        // Once behind the camera, destroy self
        if (Camera.main.transform.position.z > transform.position.z + 10)
        {
            // Tell the treeSpanwer to spawn a tree
            treeSpawner.SpawnNewTree();
            Destroy(gameObject);
        }
    }
}
