using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatJumpScript : MonoBehaviour
{
    private AudioSource myAudioSource;
    [SerializeField] private AudioClip jumpSFX;

    private CatWalkScript theCatWalk;

    [SerializeField] private ArchCalc toDrawCurve;

    private CatControls catControls;

    [SerializeField] private float minJump = 0.5f;
    [SerializeField] private float jumpMultiplier = 100f;
    [SerializeField] public float jumpAngle = 45f;

    private Rigidbody myRb;

    private Vector3 jumpDirection;

    private bool isCharging = false;
    [SerializeField] public float chargeTime = 3f;
    [SerializeField] private float chargeSpeed = 3f;
    private float currentCharge = 0f;
    private float chargeDirection = 1f;

    private CameraMoveScript camMoveScript;
    private bool hasDoneFirstJump = false;

    private void Awake()
    {
        catControls = new CatControls();
        myRb = GetComponent<Rigidbody>();
        theCatWalk = GetComponent<CatWalkScript>();
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
        catControls.Ground.Jump.started += _ => JumpStart();
        catControls.Ground.Jump.canceled += _ => JumpEnd();
        // catControls.Ground.Turning.started += _ => JumpCancel();
        catControls.Ground.FullScreen.performed += _ => ToggleFullScreen();

        myAudioSource = GetComponent<AudioSource>();

        camMoveScript = Camera.main.transform.parent.GetComponent<CameraMoveScript>();

        currentCharge = minJump;
    }

    void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    private void Update()
    {
        if (isCharging)
        {
            currentCharge += Time.deltaTime * chargeSpeed * chargeDirection;

            // Changes the chargedirection if it fills up or empties
            if (currentCharge >= chargeTime)
            {
                chargeDirection = -1f;
            }
            else if (currentCharge <= minJump)
            {
                chargeDirection = 1f;
            }

            // Tells ArchCalc what the current charge would be in velocity
            toDrawCurve.DrawThis(currentCharge * jumpMultiplier);
        }

        // Destroys the model if fallen too far
        if (transform.position.y < Camera.main.transform.position.y - 52)
        {
            Destroy(gameObject);
        }
    }

    void JumpCancel()
    {
        isCharging = false;
        currentCharge = 0f;
        toDrawCurve.gameObject.SetActive(false);
        theCatWalk.isJumping = false;
    }

    void JumpStart()
    {
        if (theCatWalk.onGround)
        {
            currentCharge = minJump;
            toDrawCurve.gameObject.SetActive(true);

            isCharging = true;
            theCatWalk.isJumping = true;
        }
    }

    void JumpEnd()
    {
        if (isCharging)
        {
            if (!hasDoneFirstJump)
            {
                camMoveScript.beginMovement = true;
                hasDoneFirstJump = true;
            }

            theCatWalk.MakeEverythingSlide(true);

            myAudioSource.PlayOneShot(jumpSFX, 0.15f);

            theCatWalk.otherGroundCheck = false;

            isCharging = false;

            // Disables line
            // toDrawCurve.gameObject.SetActive(false);

            // transform.forward gives a normalized vector in the direction the character is looking
            // Makes a normalized vector in the direction of the jump angle times look direction
            jumpDirection = Vector3.Normalize(Mathf.Cos(jumpAngle * Mathf.Deg2Rad) * transform.forward + new Vector3(0f, Mathf.Sin(jumpAngle * Mathf.Deg2Rad), 0f));

            myRb.velocity = currentCharge * jumpMultiplier * jumpDirection;

            currentCharge = minJump;

            StartCoroutine(JumpDone());
        }
    }

    private IEnumerator JumpDone()
    {
        yield return new WaitForSeconds(0.1f);
        if (!isCharging)
        {
            theCatWalk.otherGroundCheck = false;
            theCatWalk.isJumping = false;
        }
    }
}
