using System.Collections;
using System.Collections.Generic;
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
        }
        if (dashing == false)
        {
            playercollision.enabled = true;
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
    }
}
