using UnityEngine;
using System.Collections;

public class bouyancy : MonoBehaviour
{
    private float forceFactor;
    private Vector3 actionPoint;
    private Vector3 uplift;
    Vector3 buoyancyCentreOffset;

    public GameObject ocean;

    void Update()
    {
        actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
        forceFactor = 1f - ((actionPoint.y - ocean.transform.position.y) / 1F);

        if (forceFactor > 0f)
        {
           uplift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * 0.02F);
            GetComponent<Rigidbody>().AddForceAtPosition(uplift, actionPoint);
        }
    }
}