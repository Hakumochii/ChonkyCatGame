using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatJumpScript : MonoBehaviour
{
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
    private float currentCharge = 0f;
    private float chargeDirection = 1f;

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

        currentCharge = minJump;
    }

    private void Update()
    {
        if (isCharging)
        {
            currentCharge += Time.deltaTime * chargeDirection;

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
            toDrawCurve.velocity = currentCharge * jumpMultiplier;
        }
    }

    void JumpStart()
    {
        isCharging = true;
        theCatWalk.isJumping = true;
    }

    void JumpEnd()
    {
        Debug.Log("jumped with " + (currentCharge * jumpMultiplier).ToString() + " charge");

        isCharging = false;

        toDrawCurve.velocity = 0f;

        // transform.forward gives a normalized vector in the direction the character is looking
        // Makes a normalized vector in the direction of the jump angle times look direction
        jumpDirection = Vector3.Normalize(Mathf.Cos(jumpAngle * Mathf.Deg2Rad) * transform.forward + new Vector3(0f, Mathf.Sin(jumpAngle * Mathf.Deg2Rad), 0f));

        Debug.Log("Direction is " + jumpDirection);
        
        myRb.velocity = currentCharge * jumpMultiplier * jumpDirection;

        currentCharge = minJump;

        StartCoroutine(JumpDone());
    }

    private IEnumerator JumpDone()
    {
        yield return new WaitForSeconds(0.3f);
        theCatWalk.isJumping = false;
    }
}
