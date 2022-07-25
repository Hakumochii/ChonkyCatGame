using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEndless : MonoBehaviour
{
    [SerializeField] private GroundEndless nextGroundScript;

    [SerializeField] private GameObject[] groundPrefabs;
    public float vertiMoveSpeed = 0.5f;

    private CameraMoveScript camMoveScript;
    private bool beginMovement = false;

    [SerializeField] bool firstGround = false;

    // Start is called before the first frame update
    void Start()
    {
        camMoveScript = Camera.main.transform.parent.GetComponent<CameraMoveScript>();
        vertiMoveSpeed = camMoveScript.vertiMoveSpeed;

        if (firstGround)
        {
            GoSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!beginMovement)
        {
            beginMovement = camMoveScript.beginMovement;
        }
        else
        {
            transform.Translate(Vector3.up * vertiMoveSpeed * Time.deltaTime);
        }

        if (Camera.main.transform.position.z - transform.position.z > 40f)
        {
            nextGroundScript.GoSpawn();
            Destroy(gameObject);
        }
    }

    private void GoSpawn()
    {
        // If this has spawned a tree, tell that tree to spawn one
        if (nextGroundScript != null)
        {
            nextGroundScript.GoSpawn();
        } // If haven't spawned a tree, spawn one
        else
        {
            // If this is within a certain distance of the camera
            if (transform.position.z - Camera.main.transform.position.z < 110f)
            {
                // Gets location X meters ahead
                Vector3 newSpawnPos = transform.position + new Vector3(0f, 0f, 30f);

                // Spawns new tree X meters ahead and remembers its script
                nextGroundScript = Instantiate(groundPrefabs[Mathf.FloorToInt(Random.Range(0f, groundPrefabs.Length))], newSpawnPos, Quaternion.identity).GetComponent<GroundEndless>();

                // Spawn another tree further along
                nextGroundScript.GoSpawn();
            }
        }
    }
}
