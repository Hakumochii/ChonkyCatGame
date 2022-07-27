using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDeath : MonoBehaviour
{
    public NewGroundSpawner groundSpawner;

    // Update is called once per frame
    void Update()
    {
        // Once behind the camera, destroy self
        if (Camera.main.transform.position.z > transform.position.z + 60)
        {
            // Tell the groundSpawner to spawn a ground patch
            groundSpawner.SpawnNewGround();
            Destroy(gameObject);
        }
    }
}
