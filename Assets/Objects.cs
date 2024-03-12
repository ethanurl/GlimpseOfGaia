using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private bool pickable = false;
    private bool follower = false;
    private bool circling = false;
    public GameObject Player;
    private float distance;
    public GameObject Gaia;
    public AudioSource pickupsound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // This Part is for picking up and following the player
        if (pickable == true)
        {
            if (Input.GetKeyDown("e"))
            {
                pickupsound.Play();
                follower = true;
            }
        }
        if (follower == true)
        {
            distance = Vector2.Distance(transform.position, Player.transform.position);
            if (distance >= 6)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, distance*10 * Time.deltaTime);
            }
        }
        //This part is for circling around Gaia once placed there
        if (circling == true)
        {
            transform.RotateAround(Gaia.transform.position, Vector3.right, 20*Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            pickable = true;
            Debug.Log("yomama");
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            Debug.Log("okeydokey");
            pickable = false;
        }
    }
}