using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public Animator anim;
    float audioVolume = 1.0f;
    public AudioSource audioSource;
    bool fade = false;
    private bool optionsOpen = false;
    public GameObject optionMenu;

	void Start ()
    {
	}
	
    public void onPlay()
    {
        Application.LoadLevel("Main");
    }

    public void onOptions()
    {
        optionMenu.SetActive(!optionsOpen);
        optionsOpen = !optionsOpen;
    }

    void Update()
    {
        if(fade)
        {
            fadeOut();
        }
    }

    void fadeOut()
    {
        if (audioVolume > 0.0f)
        {
            audioVolume -= 0.4f * Time.deltaTime;
            audioSource.volume = audioVolume;
        }
    }
}
