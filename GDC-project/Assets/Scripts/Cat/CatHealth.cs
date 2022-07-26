using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    private bool hasDied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDied)
        {
            if (other.tag == "Death" || other.tag == "Enemy")
            {
                hasDied = true;
                Death();
            }
        }
    }

    void Death()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().Death();

        Debug.Log("Chonker am death");
    }
}
