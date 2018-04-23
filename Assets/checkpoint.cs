using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

    static public bool madeIt = false;

    public Transform camera1Spot;
    public Transform camera2Spot;
    public Transform checkpointSpot;

    public GameObject player;
    public GameObject camera1;
    public GameObject camera2;

	// Use this for initialization
	void Start () {
        if(madeIt)
        {
            Debug.Log("here");
            camera1.transform.position = camera1Spot.position;
            camera2.transform.position = camera2Spot.position;
            player.transform.position = checkpointSpot.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O))
        {
            setCheck();
        }
	}

    public void setCheck()
    {
        madeIt = true;
    }

    public bool getCP()
    {
        return madeIt;
    }
}
