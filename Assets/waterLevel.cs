using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterLevel : MonoBehaviour {

    [SerializeField]
    private float heighestHeight;
    [SerializeField]
    private float lowestHeight;

    [SerializeField]
    private DayCycle time;

    private int dayOrNight;

    public bool isRising;

	// Use this for initialization
	void Start () {
        dayOrNight = 1;
        isRising = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (time.currentTimeOfDay > 0.3 && transform.position.y > lowestHeight && time.currentTimeOfDay < 0.65)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }

        if(time.currentTimeOfDay > 0.7 && transform.position.y < heighestHeight)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        

        
        
    }
}
