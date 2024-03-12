using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private bool pickable = false;
    private bool follower = false;
    private bool circling = false;
    private bool placable = false;
    public GameObject Player;
    private float distance;
    public GameObject Gaia;
    public AudioSource pickupsound;
    public PlayerScript player1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   // This Part is for picking up and following the player
        if (Player.transform.position.y > 233 && follower == true)
        {
            placable = true;
            pickable = false;
        } else {
            placable = false;
        }

        if (pickable == true && player1.hasfollower == false)
        {
            if (Input.GetKeyDown("e"))
            {
                pickupsound.Play();
                follower = true;
                player1.hasfollower = true;
            }
        }
        if (follower == true)
        {
            pickable = false;
            player1.hasfollower = true;
            distance = Vector2.Distance(transform.position, Player.transform.position);
            if (distance >= 6)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, distance*10 * Time.deltaTime);
            }
        }
        if (placable == true)
        {
            if (Input.GetKeyDown("e") && player1.hasfollower == true)
            {
                circling = true;
                follower = false;
                player1.hasfollower = false;
                player1.pickedup += 1;
            }
        }
        //This part is for circling around Gaia once placed there
        if (circling == true)
        {
            transform.RotateAround(Gaia.transform.position, new Vector3(0,0,-0.1f), 50f * Time.deltaTime);
            pickable = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            pickable = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            pickable = false;
        }
    }
}
