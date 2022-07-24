using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalkScript : MonoBehaviour
{
    private CatControls catControls;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float turnSpeed = 15f;

    private float turnDirection = 0f;

    private void Awake()
    {
        catControls = new CatControls();
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
        turnDirection = catControls.Ground.Turning.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        // Sets the rotation to new value
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnSpeed * turnDirection, 0f));
    }
}
