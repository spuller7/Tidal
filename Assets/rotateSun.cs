using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSun : MonoBehaviour {

    [SerializeField]
    private int normalSpeed;
    [SerializeField]
    private int fastSpeed;

    private int speed;

	// Use this for initialization
	void Start () {
        speed = normalSpeed;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.W))
        {
            speed = fastSpeed;
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            speed = normalSpeed;
        }

        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
