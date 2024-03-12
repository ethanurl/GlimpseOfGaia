using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public CircleCollider2D playercollision;
    public Rigidbody2D PlayerBody;
    private Vector2 mover;
    public float movespeed = 30f;
    private float dashcd = 5f;
    private float dashduration = 5f;
    private bool dashing;
    public Slider dashtimer;
    public Camera yocamera;
    public AudioSource dashsound;
    public Animator playeranim;
    float newval;
    public TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        ///THIS IS PLAYER MOVEMENT
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashcd >= 3f)
            {
                dashsound.Play();
                dashing = true;
                if (dashduration == 5f)
                {
                    movespeed = 130f;
                }
                dashduration = 4.9f;
            }
        }
        if (dashduration != 5f)
        {
            dashduration -= Time.deltaTime * 20f;
        }
        if (dashduration <= 0)
        {
            dashing = false;
            movespeed = 30f;
            dashduration = 5f;
            dashcd = 0f;
        }
        if (dashcd <= 3f)
        {
            dashcd += Time.deltaTime;
        }
        
        mover.y = Input.GetAxisRaw("Vertical");
        mover.x =  Input.GetAxisRaw("Horizontal");
        mover.Normalize();
        PlayerBody.velocity = mover * movespeed;
        if (dashing == true)
        {
            playercollision.enabled = false;
            trail.enabled = true;
        }
        if (dashing == false)
        {
            playercollision.enabled = true;
            trail.enabled = false;
        }
        dashtimer.value = dashcd;
        //This part is going to be how the camera moves when the player goes through different screens
        if (this.transform.position.y - yocamera.transform.position.y > 40)
        {
            Vector3 up = new Vector3(0, 80, 0);
            yocamera.transform.position += up;
        }
        if (this.transform.position.y - yocamera.transform.position.y < -40)
        {
            Vector3 up = new Vector3(0, 80, 0);
            yocamera.transform.position -= up;
        }
        if (this.transform.position.x - yocamera.transform.position.x > 71)
        {
            Vector3 right = new Vector3(142, 0, 0);
            yocamera.transform.position += right;
        }
        if (this.transform.position.x - yocamera.transform.position.x < -71)
        {
            Vector3 right = new Vector3(142, 0, 0);
            yocamera.transform.position -= right;
        }

        //This is the controller for the animation tree, in order to match player movement
        if (Input.anyKey == false)
        {
            playeranim.SetFloat("Blend", newval - 0.5f);
        }
        if (Input.GetKey("w"))
        {
            newval = playeranim.GetFloat("Blend");
            if (Input.GetKey("a") == false && (Input.GetKey("d") == false))
            {
                playeranim.SetFloat("Blend", 0.8f);
            }
        }
        if (Input.GetKey("a"))
        {
            newval = playeranim.GetFloat("Blend");
            playeranim.SetFloat("Blend", 0.6f);
        }
        if (Input.GetKey("s"))
        {
            newval = playeranim.GetFloat("Blend");
            if (Input.GetKey("a") == false && (Input.GetKey("d") == false))
            {
                playeranim.SetFloat("Blend", 0.5f);
            }
        }
        if (Input.GetKey("d"))
        {
            newval = playeranim.GetFloat("Blend");
            playeranim.SetFloat("Blend", 0.7f);

        }
    }
}