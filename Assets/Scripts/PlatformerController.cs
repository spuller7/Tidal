using UnityEngine;
using System.Collections;

public class PlatformerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public bool walking;
    public Animator anim;
    public Animator anim2;
    private bool canPlay;
    public GameObject introCamera;
    public GameObject playerCamera;
    public GameObject instructions;
    public AudioSource jump;
    public AudioClip jump1;
    public AudioClip jump2;
    public int currJump;
    public checkpoint cp;

    private void Start()
    {
        currJump = 1;
        canPlay = false;
        if(!checkpoint.madeIt)
        {
            StartCoroutine(startGame(5));
        }
        else
        {
            canPlay = true;
            introCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        
    }

    void Update()
    {
        if (canPlay)
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (Input.GetKeyDown(KeyCode.A))
            {
                walking = true;
                if (anim.GetBool("right") == true)
                {
                    anim.SetBool("right", false);
                    anim.SetBool("left", true);
                }
                if (controller.isGrounded)
                {
                    anim2.SetBool("walking", true);
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                walking = true;
                if (anim.GetBool("left") == true)
                {
                    anim.SetBool("left", false);
                    anim.SetBool("right", true);
                }
                if (controller.isGrounded)
                {
                    anim2.SetBool("walking", true);
                }
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {

                anim2.SetBool("walking", false);
                walking = false;
            }

            if (controller.isGrounded)
            {

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                //moveDirection.y = 0;
                if (Input.GetButton("Jump"))
                {
                    if(currJump == 1 || currJump == 2)
                    {
                        currJump++;
                        jump.PlayOneShot(jump1, 0.5F);
                    }
                    else
                    {
                        currJump = 1;
                        jump.PlayOneShot(jump2, 0.5F);
                    }
                    moveDirection.y = jumpSpeed;
                    anim2.SetBool("walking", false);
                }

            }
            else if (controller.isGrounded == false) // Here I independently allow for both X and Z movement. 

            {
                moveDirection.x = Input.GetAxis("Horizontal") * speed;
                moveDirection = transform.TransformDirection(moveDirection);// Then reassign the current transform to the Vector 3.
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (walking)
        {
            anim2.SetBool("walking", true);
        }
    }

    IEnumerator startGame(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canPlay = true;
        introCamera.SetActive(false);
        playerCamera.SetActive(true);
    }
}