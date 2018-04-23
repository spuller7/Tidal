using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScene : MonoBehaviour {

    [SerializeField]
    private int duration = 0;

	// Use this for initialization
	void Start () {
        Debug.Log("here");
        StartCoroutine(startGame(2));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator startGame(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Application.LoadLevel("Main");
    }
}
