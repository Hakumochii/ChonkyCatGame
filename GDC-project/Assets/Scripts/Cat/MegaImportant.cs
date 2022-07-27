using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaImportant : MonoBehaviour
{
    private float timeToDIE = 60f;

    private bool hasBegun = false;

    [SerializeField] private float waitTime = 60f;

    [SerializeField] private AudioClip thatMeow;

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

        Camera.main.transform.position = transform.position + transform.forward * 2 + Vector3.up * 0.5f;
        Camera.main.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180f, 0f);

        yield return new WaitForSeconds(1.5f);

        GetComponent<AudioSource>().PlayOneShot(thatMeow);

        yield return new WaitForSeconds(6.2f);

        Application.Quit();
        Debug.Log("Quit the game");
    }
}
