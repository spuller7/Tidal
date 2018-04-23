using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    // The position that that camera will be following.
    public Transform target;
    // The speed with which the camera will be following.
    [Range(0, 1)]
    public float smoothing = 1f;
    // The initial offset from the target.
    Vector3 offset;
    // Boolean to indicate we are locked on to the target and moving with it. Can set to false if we want alternate camera movement
    public bool LockedOn = false;

    public AudioSource WarpSource;
    public AudioClip WarpIn;
    public AudioClip WarpOut;

    void Start()
    {
        offset = transform.localPosition - target.localPosition;
        LockedOn = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            WarpSource.PlayOneShot(WarpIn, 0.4F);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            WarpSource.PlayOneShot(WarpOut, 0.4F);
        }
    }

    void FixedUpdate()
    {
        if (LockedOn)
        {
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.localPosition + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing);
        }
    }
}
