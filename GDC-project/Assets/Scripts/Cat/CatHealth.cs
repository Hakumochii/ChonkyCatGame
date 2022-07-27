using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

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
            if (other.tag == "Death")
            {
                hasDied = true;
                Death();
            }
            else if (other.tag == "Enemy")
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
