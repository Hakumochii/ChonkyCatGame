using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGroundSpawner : MonoBehaviour
{
    [Header("Ground prefab and current current")]
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private Transform lastGround;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewGround();
    }

    public void SpawnNewGround()
    {
        // Gets location X meters ahead
        Vector3 newSpawnPos = lastGround.position + new Vector3(0f, 0f, 30f);

        // Spawns new tree X meters ahead and remembers its script
        GameObject justSpawned = Instantiate(groundPrefab, transform);

        lastGround = justSpawned.transform;

        justSpawned.GetComponent<GroundDeath>().groundSpawner = this;

        lastGround.position = newSpawnPos;

        // If lastGround is within a certain distance of the camera
        if (lastGround.position.z - Camera.main.transform.position.z < 330f)
        {
            SpawnNewGround();
        }
    }
}
