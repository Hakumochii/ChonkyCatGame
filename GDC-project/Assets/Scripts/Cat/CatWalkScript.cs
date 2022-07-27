using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalkScript : MonoBehaviour
{
    private CatControls catControls;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float turnSpeed = 15f;

    // Materials to switch between when walking
    [SerializeField] private PhysicMaterial noSlide;
    [SerializeField] private PhysicMaterial yesSlide;
    // Colliders to switch materials on
    [SerializeField] private CapsuleCollider[] legsAndBodCol;

    private bool canSlide = true;

    private float turnDirection = 0f;
    private float moveInput = 0f;

    private Rigidbody myRb;

    public bool otherGroundCheck = true;
    public bool onGround = true;
    public bool isJumping = false;

    [SerializeField] private LayerMask layersToCheck;

    private void Awake()
    {
        catControls = new CatControls();
        myRb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        catControls.Enable();
    }

    private void OnDisable()
    {
        catControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Reads the current left/right input
        turnDirection = catControls.Ground.Turning.ReadValue<float>();

        // Reads the current forward/backwards input
        moveInput = catControls.Ground.Walking.ReadValue<float>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            otherGroundCheck = true;

            MakeEverythingSlide(false);

            other.gameObject.GetComponent<LeafAddPoint>().AddPoints();
        }
    }

    public void MakeEverythingSlide(bool yesOrNo)
    {
        if (yesOrNo)
        {
            foreach (CapsuleCollider currentPart in legsAndBodCol)
            {
                currentPart.material = yesSlide;
            }
        }
        else
        {
            foreach (CapsuleCollider currentPart in legsAndBodCol)
            {
                currentPart.material = noSlide;
            }
        }
    }

    // FixedUpdate is called once per physics iteration
    private void FixedUpdate()
    {
        if (!isJumping && otherGroundCheck)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
            // Makes the cat unable to slide
            if (canSlide)
            {
                MakeEverythingSlide(false);
                canSlide = false;
            }
        }

        // Sets the rotation to new value based on turnspeed and turndirection
        myRb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnSpeed * turnDirection, 0f)));

        if (onGround)
        {
            // Sets the rotation to new value based on turnspeed and turndirection
            // myRb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnSpeed * turnDirection, 0f)));

            // If no input registered
            if (moveInput != 0)
            {
                // Moves the cat towards the registered forward input at moveSpeed speed
                myRb.velocity = moveInput * transform.forward * moveSpeed;

                // Makes the cat able to slide (move)
                if (!canSlide)
                {
                    MakeEverythingSlide(true);
                    canSlide = true;
                }
            }
            else
            {
                // Stops the cat from sliding
                if (canSlide)
                {
                    MakeEverythingSlide(false);
                    canSlide = false;
                }
            }
        }
    }
}
