using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip ("In ms^-1")][SerializeField] float controlSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 3f;
    [Tooltip("In m")] [SerializeField] float yRange = 2f;
    [SerializeField] GameObject[] guns;
    
    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = 2.5f;
    [SerializeField] float controlPitchFactor = 10f;

    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlRollFactor = -45f;

    float xThrow, yThrow;

    bool isControlEnabled = true;

    // Use this for initialization
    void Start ()
    {


    }

    //no need in this line because we made of this object rigidbody trigger collider
    /*private void OnCollisionEnter(Collision collision)
    {
        print("Player collided with smth");
    }*/                         

  

    // Update is called once per frame

    void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }

    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        //print("xOffsetThisFrame");

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    //called by string reference
    void OnPlayerDeath()
    {
        print("Controls frozen");
        isControlEnabled = false;
    }

    private void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns(true);
        } else
        {
            ActivateGuns(false);
        }
    }

    private void ActivateGuns(bool isActive)
    {
       foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

   
    
}
