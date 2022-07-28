using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaImportant : MonoBehaviour
{
    private float timeToDIE = 60f;

    private bool hasBegun = false;

    [SerializeField] private float waitTime = 60f;

    [SerializeField] private AudioClip thatMeow;
    [SerializeField] private Transform camToGo;

    // Start is called before the first frame update
    void Start()
    {
        timeToDIE = Time.time + waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBegun)
        {
            if (GetComponent<CatWalkScript>().isJumping)
            {
                hasBegun = true;
            }

            if (timeToDIE <= Time.time)
            {
                hasBegun = true;
                StartCoroutine(DoMeow());
            }
        }
    }

    IEnumerator DoMeow()
    {
        GetComponent<CatWalkScript>().enabled = false;
        GetComponent<CatJumpScript>().enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().MoveRotation(transform.rotation);

        Camera.main.transform.position = camToGo.position;
        Camera.main.transform.rotation = camToGo.rotation;
        Camera.main.nearClipPlane = 0.0001f;

        yield return new WaitForSeconds(1.5f);

        GetComponent<AudioSource>().PlayOneShot(thatMeow, 1f);

        yield return new WaitForSeconds(6.2f);

        Application.Quit();
        Debug.Log("Quit the game");
    }
}
