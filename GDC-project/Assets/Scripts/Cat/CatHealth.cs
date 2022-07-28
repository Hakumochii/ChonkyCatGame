using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private AudioClip fallSFX;
    [SerializeField] private AudioClip crowSFX;
    [SerializeField] private AudioClip krakra;
    [SerializeField] private AudioClip catScream;

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
                myAudioSource.PlayOneShot(fallSFX);
                Death();
            }
            else if (other.tag == "Enemy")
            {
                if (Random.value > 0.05)
                {
                    myAudioSource.PlayOneShot(crowSFX, 0.8f);
                    myAudioSource.PlayOneShot(catScream, 0.4f);
                }
                else
                {
                    myAudioSource.PlayOneShot(krakra, 1f);
                }
                transform.parent.GetComponent<CatWalkScript>().enabled = false;
                transform.parent.GetComponent<CatJumpScript>().enabled = false;
                Death();
            }
        }
    }

    void Death()
    {
        hasDied = true;

        GameObject.Find("GameManager").GetComponent<GameManager>().Death();

        Debug.Log("Chonker am death");
    }
}
