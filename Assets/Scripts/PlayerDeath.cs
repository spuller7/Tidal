using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public Animator anim;
    public GameObject character;
    public PlatformerController pc;
    public AudioSource splashSource;
    public AudioClip splash;
    public checkpoint cp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == 4)
        {
            character.SetActive(false);
            anim.SetBool("over", true);
            pc.enabled = false;
            splashSource.PlayOneShot(splash, 0.4F);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 11)
        {
            anim.SetBool("win", true);
            pc.enabled = false;
        }
        if (other.gameObject.layer == 12)
        {
            anim.SetBool("checkpoint", true);
            
            cp.setCheck();
        }
    }


    public void onRespawn()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
