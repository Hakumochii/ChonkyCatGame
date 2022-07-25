using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRandomTexture : MonoBehaviour
{
    [SerializeField] private Object[] groundMaterials;

    // Start is called before the first frame update
    void Start()
    {
        groundMaterials = Resources.LoadAll("Materials/Environment/Ground/", typeof(Material));

        int a = Random.Range(0, groundMaterials.Length);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().material = (Material)groundMaterials[a];

        }
    }
}
